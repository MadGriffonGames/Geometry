using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {


	Sprite[] triangleBack;
	Sprite[] sqareBack;
	Sprite[] pentaBack;

	GameObject[] figures;
	public GameObject currentFigure;

	public Transform figureTransform;


	void Start () 
	{
		triangleBack = Resources.LoadAll<Sprite> ("Sprites/Backs/Triangle");
		sqareBack = Resources.LoadAll<Sprite> ("Sprites/Backs/Square");
		pentaBack = Resources.LoadAll<Sprite>("Sprites/Backs/Penta");

		figures = Resources.LoadAll <GameObject>("Figures");
		currentFigure = GameObject.FindGameObjectWithTag ("Figure");
		//ChangeFigure ();
	}

	public void ChangeFigure(int figureNumber)
	{
		GameObject.DestroyObject (currentFigure);
		currentFigure = GameObject.Instantiate (figures [figureNumber],figureTransform);
	}


}
