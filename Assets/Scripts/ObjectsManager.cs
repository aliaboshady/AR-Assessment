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
}
