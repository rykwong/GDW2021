using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float rayRange = 4;
    RaycastHit hit;

    private TextMeshProUGUI popup;
    [SerializeField] private GameObject sign;
    public float pushPower = 100.0f;




    private void Start()
    {
        popup = GameObject.Find("Popup").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        CastRay();
    }

    void CastRay()
    {
        Debug.DrawRay(transform.position, transform.forward * rayRange, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.CompareTag("Interactable"))
            {
                popup.SetText("Press I To Interact");
                if (Input.GetKeyDown(KeyCode.I))
                {
                    Debug.Log(gameObject);
                    hitObject.GetComponent<IInteractable>().Interact();
                }
            }
            else if (hitObject.CompareTag("Pushable"))
            {
                popup.SetText("Press Q To Push");
                if (Input.GetKey(KeyCode.Q))
                {
                    // Debug.Log(hitObject.transform.position - transform.position);
                    Vector3 direction = new Vector3(transform.forward.x, 0, transform.forward.z);
                    hitObject.GetComponent<Rigidbody>().AddForce(direction * pushPower);
                }
            }
            else if (hitObject.CompareTag("Pickable"))
            {

                popup.SetText("Press Mouse Left Button To Pick Up");


            }

            else
            {
                popup.SetText("");
                sign.SetActive(false);
            }


        }
        else
        {
            popup.SetText("");
            sign.SetActive(false);
        }
    }
}
