using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    public GameObject[] objectsToPlace;
    public string referenceName;
    public int objectIndex = 0;

    public void ObjectAppear()
	{
		HideAllObjects();
		objectsToPlace[objectIndex].SetActive(true);
	}

	public void HideAllObjects()
	{
		for (int i = 0; i < objectsToPlace.Length; i++)
		{
			objectsToPlace[i].SetActive(false);
		}
	}

	public GameObject GetNextObject()
	{
		if (++objectIndex >= objectsToPlace.Length)
		{
			objectIndex = 0;
		}
		GameObject objectToReturn = objectsToPlace[objectIndex];
		objectToReturn.SetActive(true);
		return objectToReturn;
	}

	public GameObject GetPreviousObject()
	{
		if (--objectIndex <= -1)
		{
			objectIndex = objectsToPlace.Length - 1;
		}
		GameObject objectToReturn = objectsToPlace[objectIndex];
		objectToReturn.SetActive(true);
		return objectToReturn;
	}
}
