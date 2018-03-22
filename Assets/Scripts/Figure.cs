using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    const int DEGREES = 360;
    const float MULTIPLIER = 6f;

    [SerializeField]
    GameObject figure;
    [SerializeField]
    SideCollider[] sides;
    [SerializeField]
    public Color[] currentColors;
    [SerializeField]
    public Sprite[] currentDots;

    public int edgeCount = 3;
    bool isRotate = false;
    int dir = 0;
    float sum = 0;
    float z;

    private void Awake()
    {

    }

    private void FixedUpdate()
    {
        
        if (isRotate)
        {
            z += (dir * MULTIPLIER);
            transform.rotation = Quaternion.Euler(0, 0, z);
            sum += dir * MULTIPLIER;
            if (Mathf.Abs(sum) >= DEGREES / edgeCount)
            {
                sum = 0;
                isRotate = false;
                z = 0;
                dir = 0;
            }
        }
        
    }

    public void Rotate(int _dir)
    {
        isRotate = true;
        dir = _dir;
        z = transform.rotation.eulerAngles.z;
    }
}
