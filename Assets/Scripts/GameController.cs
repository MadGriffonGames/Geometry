using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	private static GameController instance;
	public static GameController Instance
	{
		get
		{
			if (instance == null)
				instance = GameObject.FindObjectOfType<GameController>();
			return instance;
		}
	}
	[SerializeField]
	Text scoreText;
	public int score;

	public int difficultType;
	private int nextDiffScore;

	IGameEvent currentEvent;

    float timer = 0;
    bool isTimerTick;
    float delay = 0;

	IGameEvent[] events;

    private void Awake()
    {
		events = new IGameEvent[]{new EasyGameEvent(),new MediumGameEvent(), new HardGameEvent()};
		currentEvent = GetAllowableEvent ();
    }

    void Start () 
	{
		difficultType = 0; // начинаем с нуля, чтобы расширять рендж ивентов с нуля
		CalculateNextDifficultyScore ();
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
			currentEvent = GetAllowableEvent ();
            currentEvent.Execute();
            timer = 0;
            delay = Random.Range(1.5f, 2.5f);
        }
    }

	private IGameEvent GetAllowableEvent()
	{
		return events[Random.Range(0,difficultType)];  // предварительно так. рендж потом будет плавать
	}

	public void CheckGameParametres() // проверка количества очков и соответствие уровню сложности
	{
		scoreText.text = score.ToString ();
		if (score >= nextDiffScore) 
		{
			ChangeDifficult ();
			CalculateNextDifficultyScore ();
		}
	}

	public void GameOver()
	{
		scoreText.text = "SCORE = " + score.ToString ();
		isTimerTick = false;
		// STOP GAME EVENTS
	}

	IGameEvent RandomEvent()
	{
		return events[Random.Range(0,difficultType)];
	}

    void ChangeDifficult()
	{
		difficultType ++;
		CalculateNextDifficultyScore ();
	}

	void CalculateNextDifficultyScore()
	{
		nextDiffScore = difficultType * 10;
	}

    IEnumerator ActivateGameEvent()
    {
        currentEvent.Execute();
        yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
    }
}
