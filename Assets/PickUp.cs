using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody pickableRb;
    public GameObject hands;
    GameObject pickable;
    bool holding;



    void Start()
    {
        holding = false;
        pickable = null;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * 10, Color.magenta);
        RayCast();
        //if (Input.GetMouseButton(0))
        //{
        //    pickUp();
        //    holding = true;
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    DropObject();
        //    holding = false;
        //}
    }
    //private void pickUp()
    //{

    //}
    private void RayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, this.transform.forward * 10, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Pickable" && !holding)
            {
                hit.collider.GetComponent<Renderer>().material.color = Color.green;
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Holding");
                    hit.transform.position = hands.transform.position;

                }
                //pickable = hit.transform.gameObject;
                //pickableRb = pickable.GetComponent<Rigidbody>();
            }
            else
            {
                //pickable = null;
                //pickableRb = null;
            }

        }


    }
    //private void DropObject()
    //{
    //    if (pickable != null)
    //    {
    //        pickableRb.AddForce(0, 0, 0);
    //        pickableRb.useGravity = true;
    //        pickable = null;
    //        pickableRb = null;
    //    }
    //}
    //private void pickUp()
    //{
    //    if (pickable != null)
    //    {
    //        pickable.transform.position = hands.transform.position;
    //        pickableRb.useGravity = false;
    //    }
    //}

}
