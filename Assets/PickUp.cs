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
    bool dragging;



    void Start()
    {
        holding = false;
        pickable = null;
        dragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * 20, Color.magenta);
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


        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;


            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 20.0f))
            {
                if (hit.transform.tag == "Pickable")
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.green;

                    //pickable = hit.transform.gameObject;
                    //pickableRb = pickable.GetComponent<Rigidbody>();
                    //holding = true;
                    hit.transform.position = hands.transform.position;

                    hit.collider.GetComponent<Rigidbody>().isKinematic = true;

                    dragging = true;

                }

                else
                {
                    
                }

            }


        }
        if (Input.GetMouseButton(1))
        {

        }










    }
    private void DropObject()
    {
        //if (pickable != null)
        //{
        //    pickableRb.AddForce(0, 0, 0);
        //    pickableRb.useGravity = true;
        //    pickable = null;
        //    pickableRb = null;
        //}
    }
    //private void pickUp()
    //{
    //    if (pickable != null)
    //    {
    //        pickable.transform.position = hands.transform.position;
    //        pickableRb.useGravity = false;
    //    }
    //}

}
