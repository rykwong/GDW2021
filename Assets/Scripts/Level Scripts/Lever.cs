using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject target;
    public void Interact()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
        target.GetComponent<ITriggerable>().Trigger();
        tag = "Untagged";
    }
}
