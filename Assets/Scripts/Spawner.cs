using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private float radius = 50f;
	public Element newElement;

	void SpawnElement()
	{
		
		Instantiate(newElement,generatePoint(),Quaternion.Euler(0,0,0));
		newElement.transform.position = generatePoint ();
	}

	Vector3 generatePoint()
	{
		return new Vector3 (0, 0, 0);
	}

	Color ChooseColor()
	{
		return Color.black;
	}

}
