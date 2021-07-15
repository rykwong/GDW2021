using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour, ITriggerable
{
    private int triggers = 0;
    [SerializeField] private int triggersNeeded;
    public void Trigger()
    {
        triggers++;
    }

    private void Update()
    {
        if (triggers == triggersNeeded) Dis();
    }

    private void Dis()
    {
        gameObject.SetActive(false);
    }
}
