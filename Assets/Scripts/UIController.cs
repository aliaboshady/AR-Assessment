using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] Text objectName;
    [SerializeField] Text description;
	ObjectInfo currentObjectInfo;
	ObjectsManager currentObjectManager;

	public void OpenPanel()
	{
		if(currentObjectInfo != null)
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

	//public void NextObject()
	//{
	//	HideAllObjects();
	//	if (++objectIndex >= objectsToPlace.Length)
	//	{
	//		objectIndex = 0;
	//	}
	//	objectsToPlace[objectIndex].SetActive(true);
	//}

	//public void PrevObject()
	//{
	//	HideAllObjects();
	//	if (--objectIndex <= -1)
	//	{
	//		objectIndex = objectsToPlace.Length - 1;
	//	}
	//	objectsToPlace[objectIndex].SetActive(true);
	//}

	private void Update()
	{
		OnTouchObject();
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
						currentObjectManager = touchedObjectInfo.objectManager; ;
						OpenPanel();
					}
				}
			}
		}
	}
}
