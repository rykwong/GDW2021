using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject target;
    public void Interact()
    {
        target.GetComponent<ITriggerable>().Trigger();
    }
}
