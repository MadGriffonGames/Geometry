using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public int score;

	public int difficultType;
	private int nextDiffScore;

    EasyGameEvent currentEvent;

    float timer = 0;
    bool isTimerTick;
    float delay = 0;

    private void Awake()
    {
        currentEvent = new EasyGameEvent();
    }

    void Start () 
	{
		difficultType = 1;
		CalculatenextDifficultyScore ();
        delay = Random.Range(1.5f, 2.5f);
        isTimerTick = true;
    }

    private void FixedUpdate()
    {
        if (isTimerTick)
        {
            timer += Time.fixedDeltaTime;
        }
        if (timer >= delay)
        {
            currentEvent.Execute();
            timer = 0;
            delay = Random.Range(1.5f, 2.5f);
        }
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

    IEnumerator ActivateGameEvent()
    {
        currentEvent.Execute();
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
    }
}
