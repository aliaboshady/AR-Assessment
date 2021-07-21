using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine;

public class ImageTracking : MonoBehaviour
{
	[SerializeField] Canvas canvas;
	[SerializeField] ObjectsManager[] objectsManagers;

	Dictionary<string, ObjectsManager> objectsManagersDict = new Dictionary<string, ObjectsManager>();
	ARTrackedImageManager trackedImageManager;

	UIController UIcontroller;

	private void Awake()
	{
		trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
		UIcontroller = FindObjectOfType<UIController>();

		foreach (ObjectsManager objectManager in objectsManagers)
		{
			objectsManagersDict.Add(objectManager.referenceName, objectManager);
		}
	}

	void OnApplicationPause()
	{
		RemoveAllObjects();
	}

	private void OnEnable()
	{
		trackedImageManager.trackedImagesChanged += ImageChanged;
	}

	private void OnDisable()
	{
		trackedImageManager.trackedImagesChanged -= ImageChanged;
	}

	void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
	{
		foreach (ARTrackedImage trackedImage in eventArgs.added)
		{
			UpdateObject(trackedImage);
		}

		foreach (ARTrackedImage trackedImage in eventArgs.updated)
		{
			if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
			{
				UpdateObject(trackedImage);
			}
			else if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited)
			{
				RemoveUntrackedObject(trackedImage);
			}
		}
	}

	void UpdateObject(ARTrackedImage trackedImage)
	{
		string name = trackedImage.referenceImage.name;
		Vector3 position = trackedImage.transform.position;

		ObjectsManager tempObjectsManager = objectsManagersDict[name];
		int tempIndex = tempObjectsManager.objectIndex;
		GameObject tempObject = tempObjectsManager.objectsToPlace[tempIndex];

		tempObject.transform.position = position;
		tempObjectsManager.ObjectAppear();

		UIcontroller.AssignObjectToPanelFromManager(tempObjectsManager);
	}

	void RemoveUntrackedObject(ARTrackedImage trackedImage)
	{
		string name = trackedImage.referenceImage.name;
		ObjectsManager tempObjectsManager = objectsManagersDict[name];
		int tempIndex = tempObjectsManager.objectIndex;
		GameObject tempObject = tempObjectsManager.objectsToPlace[tempIndex];
		tempObject.SetActive(false);
	}

	void RemoveAllObjects()
	{
		foreach (ObjectsManager objectManager in objectsManagers)
		{
			objectManager.HideAllObjects();
		}
	}
}
