using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private bool reset;
    [SerializeField] private Vector3 spawnpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(reset) GameObject.Find("GameManager").GetComponent<HiddenPuzzleManager>().GeneratePuzzle();
        if (other.gameObject.CompareTag("Player")) other.transform.position = spawnpoint;
        else if(other.GetComponent<Respawnable>()) other.GetComponent<Respawnable>().Respawn();
    }
}
