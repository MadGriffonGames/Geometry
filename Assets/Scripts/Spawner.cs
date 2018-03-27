using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject elementPrefab;
    private float radius = 7f;
    public float maxSpeed;
    public float maxAmplitude;
    public float maxFrequency;
    [HideInInspector] public enum MoveTypes { Linear = 0, Sinus = 1, Spiral = 2 };
    [HideInInspector] public int elementSpeed;
    [HideInInspector] public Color[] availiableColors;
    [HideInInspector] public Sprite[] availiableDots;
    Figure figure;

    private void Awake()
    {
		PoolManager.Instance.CreatePool (elementPrefab, 10);
		figure = FindObjectOfType<Figure> ();
		availiableColors = figure.currentColors;
        availiableDots = figure.currentDots;
    }

    public void SpawnElement(MoveTypes moveType)
    {
        switch (moveType)
        {
            case MoveTypes.Linear:
				SpawnAnotherSpiralElement(GenerateSpeed());
                break;
            case MoveTypes.Sinus:
				SpawnAnotherSpiralElement(GenerateSpeed());
                break;
            case MoveTypes.Spiral:
				SpawnAnotherSpiralElement(GenerateSpeed());
                break;
            default:
                break;
        }
    }

    public Element SpawnLinearElement(float speed)
    {
        GameObject tmpObj = PoolManager.Instance.ReuseElement(elementPrefab, GeneratePoint(), Quaternion.identity);

        Element element = tmpObj.GetComponent<Element>();
        element.speed = speed;
        element.moveType = element.LinearMove;
        SetElementVisual(element);
        return element;
    }

	public void SpawnSinusElement(float speed, float ampletude, float frequency)
	{
        Element element = SpawnLinearElement(speed);
        element.moveType = element.AnotherSinusMove;
        element.ampletude = ampletude;
        element.frequency = frequency;
    }

	public void SpawnAnotherSinusElement(float speed)
	{
		GameObject tmpObj = PoolManager.Instance.ReuseElement (elementPrefab, GeneratePoint(), Quaternion.identity);
		float tmpX;
		float sign = 1f;

		Element element = tmpObj.GetComponentInChildren<Element>();
		Vector3 direction = (element.targetPoint - tmpObj.transform.position).normalized;
		if (tmpObj.transform.position.x < -10f) {
			tmpX = 1f;
		} else {
			tmpX = -1f;
			speed *= -1f;
		}

		if ((tmpObj.transform.position.y <= 0.3f && tmpObj.transform.position.x >= -10f) || (tmpObj.transform.position.y >= 0.3f && tmpObj.transform.position.x <= -10f)) {
			sign = -1f;
		}
		
		tmpObj.transform.rotation = Quaternion.Euler(0, 0, sign * Vector3.Angle(new Vector3(tmpX, 0, 0), direction));
		
		element.speed = speed/2f;
		SetElementVisual (element);
		element.moveType = element.AnotherSinusMove;
	}

    public void SpawnSpiralElement(float speed)
    {
        Element element = SpawnLinearElement(speed);
        element.moveType = element.SpiralMove;
    }

	public void SpawnAnotherSpiralElement(float speed)
	{
		GameObject tmpObj = PoolManager.Instance.ReuseElement (elementPrefab, GeneratePoint(), Quaternion.identity);
		Element element = tmpObj.GetComponentInChildren<Element>();
		SetElementVisual (element);
		element.moveType = element.SpiralMove;
	}

    void SetElementVisual(Element element)
    {
        int rnd = Random.Range(0, availiableColors.Length);

        element.colorId = ChooseColor(rnd);
        SetTail(element, rnd);
        element.mySpriteRenderer.sprite = ChooseSprite(rnd);
    }

	Vector3 GeneratePoint()
	{
		Vector3 newPoint = new Vector3 (0, 0, 0);
		int degree = UnityEngine.Random.Range (0, 360);
		newPoint.x = figure.transform.position.x + radius * Mathf.Cos(degree);
		newPoint.y = figure.transform.position.y + radius * Mathf.Sin(degree);

		return newPoint;
	}

    float GenerateSpeed()
    {
        return Random.Range(1f, maxSpeed + 1f);
    }

    float GenerateAmplitude()
    {
        return Random.Range(1f, maxAmplitude + 1f);
    }

    float GenerateFrequency()
    {
        return Random.Range(1f, maxFrequency + 1f);
    }

    void SetTail(Element element, int rnd)
    {
        element.tail.Stop();
        var psmain = element.tail.main;
        psmain.startColor = ChooseColor(rnd);
        element.tail.Play();
    }

    Color ChooseColor(int rnd)
    {
        return availiableColors[rnd];
    }

    Sprite ChooseSprite(int rnd)
    {
        return availiableDots[rnd];
    }

}
