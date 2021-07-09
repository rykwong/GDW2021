using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = spawnpoint.transform.position;
    }
}
