using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    //[SerializeField] private GameObject target;
    //if you have multiple targets in your scene that you want to trigger and have something done
    //you can do so. 
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].GetComponent<ITriggerable>().Trigger();

        }
    }
}
