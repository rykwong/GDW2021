using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    float throwForce = 600;
    Transform currentTransform;
    float distanceBetween;
    RaycastHit hit;
    public LayerMask RayMask;
    public Transform handPosition;
    public bool grabbed;
    Vector3 v3_rotation;
    bool b_IsRotating = false;

    void Start()
    {
        grabbed = false;
    }

    // Update is called once per frame
    void Update()
    {

        PickUpObj();

    }

    void PickUpObj()
    {

        //press E -> 
        //ray cast on to object -> if hit.transform.tag == "Pickable"
        // hit.parent = camera.parent
        Debug.DrawRay(transform.position, transform.forward * 20, Color.red);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 5, RayMask))
            {
                if (hit.transform.tag == "Pickable")
                {
                    Debug.Log(hit.transform.gameObject);
                    SetNewTransform(hit.transform);

                    hit.transform.GetComponent<Rigidbody>().useGravity = false;
                    hit.transform.GetComponent<Rigidbody>().detectCollisions = true;

                    grabbed = true;
                    if (grabbed)
                    {

                        hit.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        hit.transform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                        hit.transform.parent = handPosition.transform;
                    }
                    //float x = hit.transform.localRotation.x;
                    //float y = hit.transform.localRotation.y;
                    //float z = hit.transform.localRotation.z;

                    //if (Input.GetKey(KeyCode.Alpha1))
                    //{

                    //    hit.transform.eulerAngles = new Vector3(x++, y, z);

                    //}
                    //else if (Input.GetKey(KeyCode.Alpha2))
                    //{
                    //    hit.transform.eulerAngles = new Vector3(x, y++, z);
                    //}
                    //else if (Input.GetKey(KeyCode.Alpha3))
                    //{
                    //    hit.transform.eulerAngles = new Vector3(x, y, z++);
                    //}
                }


            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            RemoveTransform();
            if (grabbed)
            {
                hit.transform.parent = null;
                hit.transform.GetComponent<Rigidbody>().useGravity = true;

            }

            grabbed = false;
            //if (hit.transform.gameObject.GetComponent<Transform>().parent != null)
            //{

            //}
            //if (hit.transform.gameObject.GetComponent<Transform>().parent == null)
            //{
            //    return;
            //}
            //else
            //{
            //    hit.transform.gameObject.GetComponent<Transform>().parent = null;
            //}


        }

        //rotate a picked up object
        if (Input.GetKey(KeyCode.Alpha1))
        {
            //hit.transform.localEulerAngles = new Vector3()
            v3_rotation = new Vector3(1, 0, 0);
            hit.transform.Rotate(v3_rotation * 2, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            //hit.transform.localEulerAngles = new Vector3()
            v3_rotation = new Vector3(0, 1, 0);
            hit.transform.Rotate(v3_rotation * 2, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            //hit.transform.localEulerAngles = new Vector3()
            v3_rotation = new Vector3(0, 0, 1);
            hit.transform.Rotate(v3_rotation * 2, Space.Self);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            //hit.transform.localEulerAngles = new Vector3()
            v3_rotation = new Vector3(-1, 0, 0);
            hit.transform.Rotate(v3_rotation * 2, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            //hit.transform.localEulerAngles = new Vector3()
            v3_rotation = new Vector3(0, -1, 0);
            hit.transform.Rotate(v3_rotation * 2, Space.Self);
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            //hit.transform.localEulerAngles = new Vector3()
            v3_rotation = new Vector3(0, 0, -1);
            hit.transform.Rotate(v3_rotation * 2, Space.Self);
        }

        //if there is a current transform, we want to move the transform around.
        if (currentTransform)
        {
            MoveTransformAround();
        }
    }
    //set the picked up object's transform = to the currentTransform.
    //find distance between camera and
    //set the 
    void SetNewTransform(Transform newTransform)
    {
        //if the current transform != null
        if (currentTransform)
        {
            return;
        }

        currentTransform = newTransform;
        distanceBetween = Vector3.Distance(handPosition.position, currentTransform.position);

        //currentTransform.GetComponent<Rigidbody>().isKinematic = true;
    }
    //move around while holding the object
    private void MoveTransformAround()
    {
        currentTransform.position = handPosition.position + handPosition.forward * distanceBetween;
    }
    //drop object
    public void RemoveTransform()
    {
        if (!currentTransform)
        {
            return;
        }
        //currentTransform.GetComponent<Rigidbody>().isKinematic = false;
        currentTransform = null;
    }




}
