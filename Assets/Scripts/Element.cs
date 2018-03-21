using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
	public float speed;
    [SerializeField]
    public SpriteRenderer mySpriteRenderer;
    Vector3 targetPoint;

    private void Awake()
    {
        targetPoint = new Vector3(-10, 0.3f, 0);
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
