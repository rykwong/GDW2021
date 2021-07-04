using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float rayRange = 4;
    RaycastHit hit;
    void Update()
    {
        CastRay();
    }

    void CastRay()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (Input.GetKeyDown(KeyCode.I))
            {
                hitObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
