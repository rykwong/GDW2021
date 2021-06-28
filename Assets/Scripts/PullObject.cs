using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 *This script needs more work. 
 */
public class PullObject : MonoBehaviour
{
    Transform currentTransform;
    float distanceBetween;
    RaycastHit hit;
    public LayerMask RayMask;
    public Transform handPosition;
    bool pulling;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PullObj();
    }
    void PullObj()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 20, RayMask))
            {
                if (hit.transform.tag == "Pullable")
                {
                    Debug.Log(hit.transform.gameObject);
                    //SetNewTransform(hit.transform);
                    hit.transform.parent = handPosition.parent;
                    pulling = true;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //RemoveTransform();
            if (pulling)
            {
                hit.transform.parent = null;
            }


        }



    }

    void SetNewTransform(Transform newTransform)
    {
        if (currentTransform)
        {
            return;
        }
        currentTransform = newTransform;
        distanceBetween = Vector3.Distance(transform.position, newTransform.position);
        //currentTransform.GetComponent<Rigidbody>().isKinematic = true;
    }
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

