using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour, IInteractable
{
    [SerializeField] private List<GameObject> target = new List<GameObject>();
    private int index = 0;
    public void Interact()
    {
        //target[index].GetComponent<ITriggerable>().Trigger();
        for (int i = 0; i < target.Capacity; i++)
        {
            target[i].GetComponent<ITriggerable>().Trigger();
        }
    }
}
