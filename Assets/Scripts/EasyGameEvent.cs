using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EasyGameEvent : MonoBehaviour, IGameEvent
{
    const int ELEMENTS_RANGE_BEGIN = 1;
    const int ELEMENTS_RANGE_END = 6;
    
    int elemetsCount;
    GameController gameController;
    [SerializeField] Spawner spawner = FindObjectOfType<Spawner>();
    

    public void Execute()
    {
        elemetsCount = 1;
        for (int i = 0; i < elemetsCount; i++)
        {
            spawner.SpawnElement(RandomEnumValue<Spawner.MoveTypes>());
        }
		
    }

    static T RandomEnumValue<T>()
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(new System.Random().Next(v.Length));
    }

}
