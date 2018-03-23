using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour {

	static PoolManager _instance;
	public static PoolManager Instance 
	{
		get 
		{
			if (_instance == null)
				_instance = FindObjectOfType<PoolManager> ();
			return _instance;
		}
	}

	Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

	public void CreatePool(GameObject elementPrefab, int poolSize)
	{
		int poolKey = elementPrefab.GetInstanceID();

		if (!poolDictionary.ContainsKey (poolKey))
		{
			poolDictionary.Add(poolKey, new Queue<GameObject>());

			for (int i = 0; i < poolSize; i++) 
			{
				GameObject newObject = Instantiate (elementPrefab) as GameObject;
				newObject.SetActive (false);
				newObject.transform.parent = this.transform;
				poolDictionary [poolKey].Enqueue (newObject);
			}
		}

	}

	public GameObject ReuseElement(GameObject elementPrefab, Vector3 generatedPosition, Quaternion rotation)
	{
		int poolKey = elementPrefab.GetInstanceID();
		if (poolDictionary.ContainsKey (poolKey)) 
		{
			GameObject elementToReuse = poolDictionary [poolKey].Dequeue ();
			poolDictionary [poolKey].Enqueue (elementToReuse);




			elementToReuse.transform.position = generatedPosition;
			elementToReuse.transform.rotation = rotation;
			elementToReuse.SetActive (true);

			return elementToReuse;
		}
		return null;
	}

}

