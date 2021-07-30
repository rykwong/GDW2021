using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour, ITriggerable
{
    private bool isRotating;
    private float speed = 50f;
    private Quaternion to;
    [SerializeField] private float rotate;

    private void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, to, speed * Time.deltaTime);
        }

        if (transform.rotation == to)
        {
            isRotating = false;
        }
    }

    public void Trigger()
    {
        if (!isRotating)
        {
            isRotating = true;
            to = transform.rotation * Quaternion.Euler(0, 0, rotate);
        }
    }
}
