using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 spawnpoint;
    [SerializeField] private bool reset;

    private void OnTriggerEnter(Collider other)
    {
        if(reset) GameObject.Find("GameManager").GetComponent<HiddenPuzzleManager>().GeneratePuzzle();
        other.transform.position = spawnpoint;
    }
}
