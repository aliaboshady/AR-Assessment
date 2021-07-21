using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image panel;

	public void OpenPanel()
	{
		panel.gameObject.SetActive(true);
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
		if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider != null)
				{
					OpenPanel();
					//GameObject touchedObject = hit.transform.gameObject;
				}
			}
		}
	}
}
