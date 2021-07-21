using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[SerializeField] Image panel;
	[SerializeField] Text objectName;
	[SerializeField] Text description;
	[SerializeField] float rotateSpeed;
	[SerializeField] float scaleSpeed;
	[SerializeField] float minScale;
	[SerializeField] float maxScale;

	ObjectInfo currentObjectInfo;
	ObjectsManager currentObjectManager;

	bool rotateRight = false;
	bool rotateLeft = false;
	bool scaleBig = false;
	bool scaleSmall = false;

	private void Update()
	{
		OnTouchObject();

		if (rotateRight)
		{
			RotateRight();
		}
		if (rotateLeft)
		{
			RotateLeft();
		}
		if (scaleBig)
		{
			ScaleBig();
		}
		if (scaleSmall)
		{
			ScaleSmall();
		}
	}

	public void OpenPanel()
	{
		if (currentObjectInfo != null)
		{
			panel.gameObject.SetActive(true);
			objectName.text = currentObjectInfo.objectName;
			description.text = currentObjectInfo.objectDescription;
		}
	}

	public void ClosePanel()
	{
		panel.gameObject.SetActive(false);
	}

	public void NextObject()
	{
		if (currentObjectManager != null)
		{
			currentObjectInfo = currentObjectManager.GetNextObject().GetComponent<ObjectInfo>();
			currentObjectManager.ObjectAppear();
			OpenPanel();
		}
	}

	public void PrevObject()
	{
		if (currentObjectManager != null)
		{
			currentObjectInfo = currentObjectManager.GetPreviousObject().GetComponent<ObjectInfo>();
			currentObjectManager.ObjectAppear();
			OpenPanel();
		}
	}

	public void OnRotateRightDown()
	{
		rotateRight = true;
	}
	public void OnRotateRightUp()
	{
		rotateRight = false;
	}

	public void OnRotateLeftDown()
	{
		rotateLeft = true;
	}

	public void OnRotateLeftUp()
	{
		rotateLeft = false;
	}
	public void OnScaleBigDown()
	{
		scaleBig = true;
	}
	public void OnScaleBigUp()
	{
		scaleBig = false;
	}

	public void OnScaleSmallDown()
	{
		scaleSmall = true;
	}

	public void OnScaleSmallUp()
	{
		scaleSmall = false;
	}

	void RotateRight()
	{
		if (currentObjectInfo != null)
		{
			currentObjectInfo.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
		}
	}

	void RotateLeft()
	{
		if (currentObjectInfo != null)
		{
			currentObjectInfo.transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
		}
	}

	void ScaleBig()
	{
		if (currentObjectInfo != null)
		{
			Vector3 scale = currentObjectInfo.transform.localScale;
			if(scale.x < maxScale)
			{
				float delta = scaleSpeed * Time.deltaTime;
				scale += new Vector3(delta, delta, delta);
				currentObjectInfo.transform.localScale = scale;
			}
		}
	}
	void ScaleSmall()
	{
		if (currentObjectInfo != null)
		{
			Vector3 scale = currentObjectInfo.transform.localScale;
			if (scale.x > minScale)
			{
				float delta = scaleSpeed * Time.deltaTime;
				scale -= new Vector3(delta, delta, delta);
				currentObjectInfo.transform.localScale = scale;
			}
		}
	}

	void OnTouchObject()
	{
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null)
				{
					GameObject touchedObject = hit.transform.gameObject;
					ObjectInfo touchedObjectInfo = touchedObject.GetComponent<ObjectInfo>();

					OpenPanel();

					if (touchedObjectInfo != null)
					{
						currentObjectInfo = touchedObjectInfo;
						currentObjectManager = touchedObjectInfo.objectManager;
						OpenPanel();
					}
				}
			}
		}
	}

	public void AssignObjectToPanelFromManager(ObjectsManager newObjectsManager)
	{
		if (panel.gameObject.activeSelf)
		{
			currentObjectInfo = newObjectsManager.objectsToPlace[newObjectsManager.objectIndex].GetComponent<ObjectInfo>();
			currentObjectManager = newObjectsManager;
			OpenPanel();
		}
	}
}
