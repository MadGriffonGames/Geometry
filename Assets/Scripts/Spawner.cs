using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject elementPrefab;
	private float radius = 50f;
    public Color[] availiableColors;
	Figure figure;

    private void Awake()
    {
		figure = FindObjectOfType<Figure> ();
		availiableColors = figure.currentColors;
    }

    public void SpawnElement(int speed)
    {
        GameObject tmp = Instantiate(elementPrefab, GeneratePoint(), Quaternion.identity);
        
        Element element = tmp.GetComponent<Element>();
        element.speed = speed;
        element.mySpriteRenderer.color = ChooseColor();
    }

	Vector3 GeneratePoint()
	{
		Vector3 newPoint = new Vector3 (0, 0, 0);;
		int degree = UnityEngine.Random.Range (0, 360);
		newPoint.x = figure.transform.position.x + radius * Mathf.Cos(degree);
		newPoint.y = figure.transform.position.y + radius * Mathf.Cos(degree);
		return newPoint;
	}

	Color ChooseColor()
	{
        int rnd = Random.Range(0, availiableColors.Length);
        return availiableColors[rnd];
	}

}
