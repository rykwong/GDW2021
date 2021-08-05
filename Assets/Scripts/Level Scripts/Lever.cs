using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    public void Interact()
    {
        GetComponent<MeshRenderer>().material.color = Color.green;
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].GetComponent<ITriggerable>().Trigger();
        }
        tag = "Untagged";
    }
}
