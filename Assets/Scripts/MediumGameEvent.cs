using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumGameEvent : MonoBehaviour, IGameEvent{

	GameController gameController;
	[SerializeField]
	Spawner spawner = FindObjectOfType<Spawner>();

	const int SPEED_RANGE_BEGIN = 3;
	int SPEED_RANGE_END;

	const int ELEMENTS_RANGE_BEGIN = 3;
	const int ELEMENTS_RANGE_END = 8;

	int elementSpeed;
	int elemetsCount;

	private void Awake()
	{
		//SPEED_RANGE_END = gameController.difficultType;
	}

	public void Execute()
	{
		elemetsCount = 2;
		elementSpeed = Random.Range(SPEED_RANGE_BEGIN, SPEED_RANGE_END + 1);
		spawner.SpawnLinearElement(elementSpeed);
	}
}
