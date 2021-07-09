using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] instructions;
    private int index = 0;

    // Update is called once per frame
    void Update()
    {
        if (index < instructions.Length) text.SetText(instructions[index]);
        else text.SetText("");
        if (index == 0)
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                index++;
            }
        }
        if (index == 1)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                index++;
            }
        }
        else if (index == 2)
        {
            if (Input.GetButtonDown("Jump"))
            {
                index++;
            }
        }
        else if (index == 3)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                index++;
            }
        }
    }
}
