using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 spawnpoint;
    [SerializeField] private bool reset;
    [SerializeField] private bool playerOnly;

    private void OnTriggerEnter(Collider other)
    {
        if(reset) GameObject.Find("GameManager").GetComponent<HiddenPuzzleManager>().GeneratePuzzle();
        if (playerOnly)
        {
            if (other.transform.CompareTag("Player"))
            {
                other.transform.position = spawnpoint;
            }
        }
        else
        {
            other.transform.position = spawnpoint;
        }
    }
}
