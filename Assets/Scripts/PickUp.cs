using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody pickableRb;
    public GameObject hands;
    GameObject draggedObject = null;
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


        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;


            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 10.0f))
            {
                Debug.DrawRay(this.transform.position, this.transform.forward * 20, Color.magenta);
                if (hit.collider.tag == "Pickable")
                {
                    hit.collider.GetComponent<Renderer>().material.color = Color.green;

                    //pickable = hit.transform.gameObject;
                    //pickableRb = pickable.GetComponent<Rigidbody>();
                    //holding = true;
                    draggedObject = new GameObject();

                    draggedObject = hit.transform.gameObject;

                    if (draggedObject == null)
                    {
                        Debug.LogError("Null Pointer Exception");
                    }




                }


            }



        }

        if (Input.GetMouseButton(1))
        {

            if (draggedObject != null)
            {
                pickUp();
                draggedObject.GetComponent<Rigidbody>().isKinematic = true;
            }

        }
        if (Input.GetMouseButtonUp(1))
        {
            if (draggedObject != null)
            {
                draggedObject.GetComponent<Rigidbody>().isKinematic = false;
                draggedObject = null;

            }
            //draggedObject.GetComponent<Rigidbody>().isKinematic = false;
            //draggedObject = null;
            //Destroy(draggedObject);

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
    private void pickUp()
    {

        draggedObject.transform.position = hands.transform.position;
        Vector3 point = hands.transform.position;
        point.x = draggedObject.transform.position.x;
        point.y = draggedObject.transform.position.y;
        point.z = draggedObject.transform.position.z;
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
