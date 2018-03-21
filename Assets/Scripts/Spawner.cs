using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	GameObject figure;

	private float radius = 50f;
	public Element newElement;



	void SpawnElement()
	{
		
		Instantiate(newElement,generatePoint(),Quaternion.Euler(0,0,0));
		newElement.transform.position = generatePoint ();
	}

	Vector3 generatePoint()
	{
		Vector3 newPoint = new Vector3 (0, 0, 0);;
		int degree = UnityEngine.Random.Range (0, 360);
		newPoint.x = figure.transform.position.x + radius * Mathf.Cos(degree);
		newPoint.y = figure.transform.position.y + radius * Mathf.Cos(degree);
		return newPoint;
	}

	Color ChooseColor()
	{
		return Color.black;
	}

}
