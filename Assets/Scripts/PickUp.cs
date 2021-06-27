using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    Transform currentTransform;
    float distanceBetween;
    RaycastHit hit;
    public LayerMask RayMask;
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 40, Color.magenta);
        PickUpObj();

    }

    void PickUpObj()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 40, RayMask))
            {
                if (hit.transform.tag == "Pickable")
                {
                    Debug.Log(hit.transform.gameObject);
                    SetNewTransform(hit.transform);
                    hit.transform.gameObject.GetComponent<Transform>().parent = this.transform.parent;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RemoveTransform();
            hit.transform.gameObject.GetComponent<Transform>().parent = null;

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
        distanceBetween = Vector3.Distance(transform.position, newTransform.position);

        currentTransform.GetComponent<Rigidbody>().isKinematic = true;
    }
    //move around while holding the object
    private void MoveTransformAround()
    {
        currentTransform.position = transform.position + transform.forward * distanceBetween;
    }
    //drop object
    public void RemoveTransform()
    {
        if (!currentTransform)
        {
            return;
        }
        currentTransform.GetComponent<Rigidbody>().isKinematic = false;
        currentTransform = null;
    }




}
