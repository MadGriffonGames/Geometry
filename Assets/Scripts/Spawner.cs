using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject elementPrefab;
	private float radius = 7f;
    public Color[] availiableColors;
    public Sprite[] availiableDots;
    
    Figure figure;

    private void Awake()
    {
		figure = FindObjectOfType<Figure> ();
		availiableColors = figure.currentColors;
        availiableDots = figure.currentDots;
    }

    public void SpawnElement(int speed)
    {
        GameObject tmpObj = Instantiate(elementPrefab, GeneratePoint(), Quaternion.identity);
        
        Element element = tmpObj.GetComponent<Element>();
        element.speed = speed;
        SetElementVisual(element);
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
