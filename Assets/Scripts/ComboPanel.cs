using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboPanel : MonoBehaviour,IInteractable
{
    [SerializeField] private int value;
    private GameManager manager;
    private bool check = false;
    public bool on = false;
    private MeshRenderer meshRenderer;
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        meshRenderer = GetComponent<MeshRenderer>();
        if (on)
        {
            meshRenderer.material.color = Color.red;
        }
        else
        {
            meshRenderer.material.color = Color.gray;
        }
    }

    public void Interact()
    {
        if (!check && on && manager.solvable)
        {
            meshRenderer.material.color = Color.yellow;
            manager.Check(value);
            check = true;
        }
        
    }

    public void Reset()
    {
        check = false;
        meshRenderer.material.color = Color.red;
    }

    public void Unlock()
    {
        meshRenderer.material.color = Color.green;
        tag = "Untagged";
    }
}
