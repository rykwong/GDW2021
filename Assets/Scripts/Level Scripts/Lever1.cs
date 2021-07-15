using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject[] targets;
    public void Interact()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
        foreach (var target in targets)
        {
            target.GetComponent<ITriggerable>().Trigger();
        }
        tag = "Untagged";
    }
}
