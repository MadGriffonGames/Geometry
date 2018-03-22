using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
	public float speed;
    [SerializeField]
    public SpriteRenderer mySpriteRenderer;
    [SerializeField]
    public ParticleSystem tail;
    public Color colorId;
    Vector3 targetPoint;

    private void Awake()
    {
        targetPoint = new Vector3(-10, 0.3f, 0);
        Physics2D.Raycast(targetPoint, transform.position + targetPoint);
		//GetComponentInChildren<ParticleSystem> ().main.startColor = mySpriteRenderer.color;
    }
		
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }
}
