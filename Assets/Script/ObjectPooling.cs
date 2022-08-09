using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
	public GameObject objPrefabs;
	public int createOnStart;

	private List <GameObject> poolsObj = new List<GameObject>();
    // Start is called before the first frame update
    private void Start()
    {
		for (int x=0; x < createOnStart; x++)
		{
			CreateNewObject();
		}
    }

	GameObject CreateNewObject()
	{
		GameObject obj = Instantiate(objPrefabs);
		obj.SetActive(false);
		poolsObj.Add(obj);

		return obj;
	}
	public GameObject GetObject()
	{
		GameObject obj = poolsObj.Find(x => x.activeInHierarchy == false);
		if (obj == null)
		{
			obj = CreateNewObject();
		}
		obj.SetActive(true);

		return obj;
	}
}
