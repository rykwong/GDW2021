using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp2 : MonoBehaviour
{
    public float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    GameObject tempParent;
    public bool isHolding = false;

    Vector3 v3_rotation;

    // Update is called once per frame
    void Awake()
    {
        //Debug.Log("Hand Position:" + GameObject.Find("Camera/Hand_Position"));
        tempParent = GameObject.Find("Camera/Hand_Position");


    }
    void Update()
    {

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= 2.0f)
        {
            isHolding = false;
        }
        //Check if isholding
        if (isHolding == true)
        {

            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }

            ////rotate a picked up object
            //if (Input.GetKey(KeyCode.Alpha1))
            //{
            //    //hit.transform.localEulerAngles = new Vector3()
            //    v3_rotation = new Vector3(1, 0, 0);
            //    item.transform.Rotate(v3_rotation, Space.Self);
            //}
            //else if (Input.GetKey(KeyCode.Alpha3))
            //{
            //    //hit.transform.localEulerAngles = new Vector3()
            //    v3_rotation = new Vector3(0, 1, 0);
            //    item.transform.Rotate(v3_rotation, Space.Self);
            //}
            //else if (Input.GetKey(KeyCode.Alpha5))
            //{
            //    //hit.transform.localEulerAngles = new Vector3()
            //    v3_rotation = new Vector3(0, 0, 1);
            //    item.transform.Rotate(v3_rotation, Space.Self);
            //}

            //if (Input.GetKey(KeyCode.Alpha2))
            //{
            //    //hit.transform.localEulerAngles = new Vector3()
            //    v3_rotation = new Vector3(-1, 0, 0);
            //    item.transform.Rotate(v3_rotation, Space.Self);
            //}
            //else if (Input.GetKey(KeyCode.Alpha4))
            //{
            //    //hit.transform.localEulerAngles = new Vector3()
            //    v3_rotation = new Vector3(0, -1, 0);
            //    item.transform.Rotate(v3_rotation, Space.Self);
            //}
            //else if (Input.GetKey(KeyCode.Alpha6))
            //{
            //    //hit.transform.localEulerAngles = new Vector3()
            //    v3_rotation = new Vector3(0, 0, -1);
            //    item.transform.Rotate(v3_rotation, Space.Self);
            //}
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (distance <= 2.0f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
    }
}
