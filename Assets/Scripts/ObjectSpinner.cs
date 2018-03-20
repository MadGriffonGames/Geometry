using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpinner : MonoBehaviour
{
    const int DEGREES = 360;
    const float MULTIPLIER = 6f;

    [SerializeField]
    GameObject figure;

    public int edgeCount = 3;
    bool isRotate = false;
    int dir = 0;
    float sum = 0;
    float z;

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
        //Debug.Log(figure.transform.rotation.z);
        //figure.transform.rotation = Quaternion.Euler(0, 0, figure.transform.rotation.z + (dir * DEGREES / edgeCount));
        //Debug.Log(figure.transform.rotation.z);
        isRotate = true;
        dir = _dir;
        z = transform.rotation.eulerAngles.z;
    }
}
