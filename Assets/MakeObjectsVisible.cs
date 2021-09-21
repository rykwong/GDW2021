using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectsVisible : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets = new List<GameObject>();
    public void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            targets[i].SetActive(true);

        }
    }
}
