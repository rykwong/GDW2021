using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{
    // Start is called before the first frame updat
    public void Interact()
    {
        Debug.Log("Player interacted with me");
    }
}
