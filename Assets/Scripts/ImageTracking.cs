using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;
using UnityEngine;

public class ImageTracking : MonoBehaviour
{
	[SerializeField] ObjectsManager[] objectsManagers;
	Dictionary<string, ObjectsManager> objectsManagersDict = new Dictionary<string, ObjectsManager>();

	ARTrackedImageManager trackedImageManager;

	private void Awake()
	{
		trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

		foreach (ObjectsManager objectManager in objectsManagers)
		{
			objectsManagersDict.Add(objectManager.referenceName, objectManager);
		}
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
			UpdateImage(trackedImage);
		}

		foreach (ARTrackedImage trackedImage in eventArgs.updated)
		{
			UpdateImage(trackedImage);
		}

		foreach (ARTrackedImage trackedImage in eventArgs.removed)
		{
			//spawnedPrefab[trackedImage.name].SetActive(false);
		}
	}

	void UpdateImage(ARTrackedImage trackedImage)
	{
		string name = trackedImage.referenceImage.name;
		Vector3 position = trackedImage.transform.position;

		ObjectsManager tempObjectsManager = objectsManagersDict[name];
		int tempIndex = tempObjectsManager.objectIndex;
		GameObject tempObject = tempObjectsManager.objectsToPlace[tempIndex];

		tempObject.transform.position = position;
		tempObjectsManager.ObjectAppear();

		print(name);
	}
}
