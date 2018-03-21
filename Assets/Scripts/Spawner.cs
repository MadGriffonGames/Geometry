using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject elementPrefab;
	private float radius = 50f;
    public Color[] availiableColors;

    private void Awake()
    {
        availiableColors = FindObjectOfType<Figure>().currentColors;
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
		return new Vector3 (0, 0, 0);
	}

	Color ChooseColor()
	{
        int rnd = Random.Range(0, availiableColors.Length);
        return availiableColors[rnd];
	}

}
