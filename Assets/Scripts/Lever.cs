using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    public bool on = false;
    [SerializeField] private GameObject target;
    public void Interact()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        on = true;
        target.GetComponent<ITriggerable>().Trigger();
    }
}
