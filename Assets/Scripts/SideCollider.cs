using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour
{
    public Color ColorId;


    private void OnTriggerEnter2D(Collider2D other)
    {
		
		if (other.gameObject.GetComponent<Element>().colorId == ColorId) 
		{
			GameController.Instance.score += 1;
			GameController.Instance.CheckGameParametres ();
		} 
		else 
		{
			GameController.Instance.GameOver ();
		}
		Destroy(other.gameObject);
    }
}
