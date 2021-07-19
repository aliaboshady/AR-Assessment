using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARTapToPlaceObject : MonoBehaviour
{
    ARSessionOrigin arOrigin;
	ARRaycastManager raycastManager;
	Pose placementObject;

	private void Start()
	{
		arOrigin = FindObjectOfType<ARSessionOrigin>();
		raycastManager = FindObjectOfType<ARRaycastManager>();
	}

	private void Update()
	{
		UpdatePlacementPose();
	}

	private void UpdatePlacementPose()
	{
		Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
		var hits = new List<ARRaycastHit>();

		raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
	}
}
