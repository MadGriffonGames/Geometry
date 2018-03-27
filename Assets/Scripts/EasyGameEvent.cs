using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyGameEvent : MonoBehaviour, IGameEvent
{
    GameController gameController;
    [SerializeField]
    Spawner spawner = FindObjectOfType<Spawner>();

    const int SPEED_RANGE_BEGIN = 1;
    int SPEED_RANGE_END;

    const int ELEMENTS_RANGE_BEGIN = 1;
    const int ELEMENTS_RANGE_END = 6;

    int elementSpeed;
    int elemetsCount;

    private void Awake()
    {
        //SPEED_RANGE_END = gameController.difficultType;
    }

    public void Execute()
    {
        elemetsCount = 1;
        elementSpeed = Random.Range(SPEED_RANGE_BEGIN, SPEED_RANGE_END + 1);
        //spawner.SpawnElement(elementSpeed);
		spawner.SpawnElement(elementSpeed, 3, 3);
    }

    
}
