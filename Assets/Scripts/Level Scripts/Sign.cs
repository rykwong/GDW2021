using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject textBox;
    [SerializeField] private string text;

    public void Interact()
    {
        if (textBox.activeSelf)
        {
            textBox.SetActive(false);
        }
        else
        {
            textBox.SetActive(true);
            textBox.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
        }
    }
}
