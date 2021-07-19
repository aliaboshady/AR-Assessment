using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARTapToPlaceObject : MonoBehaviour
{
	[SerializeField] GameObject placementIndicator;
	ARRaycastManager raycastManager;
	Pose placementPose;
	bool placementPoseIsValid = false;

	private void Start()
	{
		raycastManager = FindObjectOfType<ARRaycastManager>();
	}

	private void Update()
	{
		UpdatePlacementPose();
		UpdatePlacementIndicator();
	}

	private void UpdatePlacementPose()
	{
		Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
		var hits = new List<ARRaycastHit>();
		raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

		placementPoseIsValid = hits.Count > 0;
		if (placementPoseIsValid)
		{
			placementPose = hits[0].pose;
		}
	}

	private void UpdatePlacementIndicator()
	{
		if (placementPoseIsValid)
		{
			placementIndicator.SetActive(true);
			placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
		}
		else
		{
			placementIndicator.SetActive(false);
		}
	}
}
