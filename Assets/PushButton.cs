using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    // Start is called before the first frame update
    ButtonInteract bi;
    private void Start()
    {
       bi  = new ButtonInteract();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Interactable")
        {
            Debug.Log("Player has collided");
            bi.setExtendPlatform(true);
            Debug.Log("EXTEND PLATFORM:" + bi.growPlatform);
        }
    }

}
