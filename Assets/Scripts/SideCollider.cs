﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour
{
    public Color ColorId;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.GetComponent<SpriteRenderer>().color);
        Debug.Log(ColorId);
        if (other.gameObject.GetComponent<SpriteRenderer>().color == ColorId)
        {
            Destroy(other.gameObject);
        }
    }
}
