using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour
{
    public Transform hitPoint;
    public float distance = 10f;
    public GameObject selectedObject;



    private bool isGrounded;
    private Vector3 velocity;
    RaycastHit hit;
    Vector3 offset;

    void selectObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            selectedObject = null;

        }
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                Debug.DrawRay(this.transform.position, this.transform.forward * hit.distance, Color.green);
                if (hit.collider != null)
                {
                    if (hit.collider.GetComponent<Rigidbody>() && hit.collider.tag == "Pullable")
                    {

                        Debug.Log("This object has a rigidbody.");
                        if (selectedObject == null)
                        {

                            hitPoint.transform.position = hit.point;
                            selectedObject = hit.collider.gameObject;
                            offset = selectedObject.transform.position - hit.point;
                            if (selectedObject.layer == 6)
                            {

                            }

                        }
                    }
                }
            }
            if (selectedObject != null)
            {
                selectedObject.transform.position = hitPoint.transform.position + offset;

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        selectObject();
    }
}
