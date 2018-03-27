using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardGameEvent : MonoBehaviour, IGameEvent {

	GameController gameController;
	[SerializeField]
	Spawner spawner = FindObjectOfType<Spawner>();

	const int SPEED_RANGE_BEGIN = 6;
	int SPEED_RANGE_END;

	const int ELEMENTS_RANGE_BEGIN = 6;
	const int ELEMENTS_RANGE_END = 8;

	int elementSpeed;
	int elemetsCount;

	private void Awake()
	{
		//SPEED_RANGE_END = gameController.difficultType;
	}

	public void Execute()
	{
		elemetsCount = 3;
		elementSpeed = Random.Range(SPEED_RANGE_BEGIN, SPEED_RANGE_END + 1);
		spawner.SpawnLinearElement(elementSpeed);
		Debug.Log ("hard");
	}
}
