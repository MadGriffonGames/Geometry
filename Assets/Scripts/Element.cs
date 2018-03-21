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
		//GetComponentInChildren<ParticleSystem> ().main.startColor = mySpriteRenderer.color;
    }
		
    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed * Time.deltaTime);
		CalculateRotation ();
    }

	void CalculateRotation()
	{
		transform.rotation = Quaternion.Euler(new Vector3 (0, 0, Mathf.Asin ((transform.position.x - targetPoint.x) / 7f)*Mathf.Rad2Deg));
		Debug.Log(Mathf.Asin((transform.position.x - targetPoint.x) / 7f)*Mathf.Rad2Deg);
	}
}
