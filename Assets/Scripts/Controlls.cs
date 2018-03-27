using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour
{
    [SerializeField]
    GameObject figure;
    public int edgeCount = 3;
    int dir = 0;
    float sum = 0;
    float z;
    const int DEGREES = 360;
    const float MULTIPLIER = 8f;

    private void FixedUpdate()
    {
        if (dir != 0)
        {
            z += (dir * MULTIPLIER);
            figure.transform.rotation = Quaternion.Euler(0, 0, z);
            sum += dir * MULTIPLIER;
        }
    }

    public void Rotate(int _dir)
    {
#if !UNITY_EDITOR
        dir = _dir;
        z = figure.transform.rotation.eulerAngles.z;
#endif
    }

    public void RotateEditor(int _dir)
    {
#if UNITY_EDITOR
        dir = _dir;
        z = figure.transform.rotation.eulerAngles.z;
#endif
    }
}
