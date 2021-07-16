using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector3 spawnpoint;
    private Quaternion spawnRot;

    private void Start()
    {
        spawnpoint = transform.position;
        spawnRot = transform.rotation;
    }

    public void Respawn()
    {
        if(GetComponent<Rigidbody>()) GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = spawnpoint;
        transform.rotation = spawnRot;
    }
}
