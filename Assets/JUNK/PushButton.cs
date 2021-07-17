using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    // Start is called before the first frame update
    ButtonInteract bi;
    private void Awake()
    {
        bi = new ButtonInteract();
    }
    private void Update()
    {
        //Debug.Log("GROW PLATFORM:" + bi.growPlatform);
        if (bi.growPlatform == true)
        {
            bi.scalePlatform();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Interactable")
        {
            Debug.Log("Player has collided");
            bi.setGrowPlatForm();



        }
    }

}
