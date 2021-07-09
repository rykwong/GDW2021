using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int[] solution = {1, 2, 3, 4, 5, 6, 7};
    private int current = 0;
    [SerializeField] private ComboPanel[] panels;
    public bool solvable = false;

    private void Update()
    {
        if(!solvable) CheckSolvable();
    }

    private void CheckSolvable()
    {
        foreach (ComboPanel panel in panels)
        {
            if (!panel.on)
            {
                return;
            }
        }

        solvable = true;
    }

    public void Check(int input)
    {
        // Debug.Log(input);
        if (solution[current] != input)
        {
            Reset();
            // Debug.Log("Wrong");
        }
        else
        {
            current++;
            // Debug.Log("Correct");
        }

        if (current == solution.Length)
        {
            Unlock();
        }
    }

    private void Reset()
    {
        Debug.Log("Resetting");
        current = 0;
        foreach (ComboPanel panel in panels)
        {
            panel.Reset();
        }
    }

    private void Unlock()
    {
        Debug.Log("You unlocked the vault");
        foreach (ComboPanel panel in panels)
        {
            panel.Unlock();
        }
    }
}
