using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    [SerializeField] public SpriteRenderer mySpriteRenderer;
    [SerializeField] public ParticleSystem tail;
    public float speed;
	public float ampletude;
	public float frequency;
    public float angle;
    public Color colorId;
	public Vector3 startPosition;
	public Vector3 direction;
	public Vector3 ort;
	public float startTime;
    public delegate void MoveType();
    public MoveType moveType;
	Rigidbody2D rb;
	GameObject targetObject;
    Vector3 targetPoint;

    private void Awake()
	{
		startTime = Time.time;
		angle = 0.0025f;
		rb = this.GetComponent<Rigidbody2D> ();
		targetPoint = new Vector3(-10, 0.3f, 0);
        Physics2D.Raycast(targetPoint, transform.position + targetPoint);
    }

	void OnEnable()
	{
		targetObject = GameObject.Find ("Figure");
		startPosition = transform.position;
		direction = (targetPoint - startPosition).normalized;
		ort = Vector3.Cross(direction, Vector3.forward).normalized;
	}

	void OnDisable()
	{
		speed = 0;
		colorId = new Color (1, 1, 1, 1);
	}
		
    private void FixedUpdate()
    {
        moveType.Invoke();
    }

    public void LinearMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
    }

    public void SinusMove()
	{
		float t = Time.time - startTime;
		rb.velocity = direction * speed + ort * ampletude * Mathf.Cos (frequency * t);
	}

    public void SpiralMove()
	{
		angle -= 0.0025f;
		transform.LookAt (targetObject.transform);
		transform.Translate (transform.forward * Time.deltaTime * speed);
		transform.RotateAround(targetObject.transform.position, Vector3.forward ,angle);
        transform.rotation = new Quaternion(0, 0, 0, 0);
	}
}
