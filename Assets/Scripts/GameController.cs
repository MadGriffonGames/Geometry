using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public int score;

	public int difficultType;
	private int nextDiffScore;


	void Start () 
	{
		difficultType = 1;
		CalculatenextDifficultyScore ();
	}

	void Update () 
	{
		if (score >= nextDiffScore)
			ChangeDifficult ();	
	}

	void ChangeDifficult()
	{
		difficultType ++;
		CalculatenextDifficultyScore ();
	}

	void CalculatenextDifficultyScore()
	{
		nextDiffScore = difficultType * 100;
	}

}
