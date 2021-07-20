using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARTapToPlaceObject : MonoBehaviour
{
	[SerializeField] GameObject canvas;
	[SerializeField] GameObject[] objectsToPlace;
	int objectIndex = 0;

	private void Start()
	{
		objectsToPlace[objectIndex].SetActive(true);
	}

	private void Update()
	{

		//if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		//{
			
		//}
	}

	public void ClosePanel()
	{

	}

	public void NextObject()
	{
		HideAllObjects();
		if(++objectIndex >= objectsToPlace.Length)
		{
			objectIndex = 0;
		}
		objectsToPlace[objectIndex].SetActive(true);
	}

	public void PrevObject()
	{
		HideAllObjects();
		if (--objectIndex <= -1)
		{
			objectIndex = objectsToPlace.Length - 1;
		}
		objectsToPlace[objectIndex].SetActive(true);
	}

	void HideAllObjects()
	{
		for (int i = 0; i < objectsToPlace.Length; i++)
		{
			objectsToPlace[i].SetActive(false);
		}
	}

	//private void UpdatePlacementPose()
	//{
	//	Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
	//	var hits = new List<ARRaycastHit>();
	//	raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

	//	placementPoseIsValid = hits.Count > 0;
	//	if (placementPoseIsValid)
	//	{
	//		placementPose = hits[0].pose;
	//	}
	//}

	//private void UpdatePlacementIndicator()
	//{
	//	if (placementPoseIsValid)
	//	{
	//		placementIndicator.SetActive(true);
	//		placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
	//	}
	//	else
	//	{
	//		placementIndicator.SetActive(false);
	//	}
	//}

	//private void PlaceObject()
	//{
	//	Instantiate(objectToPlace, placementPose.position, placementPose.rotation);
	//}
}
