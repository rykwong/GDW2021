using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform endPoint;
    public Transform player;
    Rigidbody rb;
    float dist;
    float rightLimit;
    float leftLimit;
    public bool start;
    Vector3 currentPosition;
    float currentDistance;
    void Start()
    {

        start = false;
        currentPosition = this.transform.position;
        currentDistance = Vector3.Distance(endPoint.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log("current position:" + currentPosition);



        if (start)
        {
            movePlatform();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            start = !start;
            //Debug.Log("START IS:" + start);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.tag == "Player")
    //    {

    //    }
    //}


    void movePlatform()
    {
        rb = GetComponent<Rigidbody>();
        dist = Vector3.Distance(endPoint.position, transform.position);
        //HARDCODED 
        //Debug.Log("Distance to endPoint:" + dist);
        if (dist == currentDistance)
        {
            rb.AddForce(transform.forward * 50);
        }
        else if (dist < 2.1)
        {
            rb.AddForce(-transform.forward * 50);
        }
    }


    //if (dist > 3 && dist < 17)
    //{
    //    rb.AddForce(transform.forward * 2);
    //}
    //else if(dist)
    //{
    //    rb.AddForce(-transform.forward * 2);
    //}
    //if (dist > 3)
    //{
    //    rb.AddForce(transform.forward * 2);
    //}
    //else if( dist == 3)
    //{

    //}


    //if (dist )
    //{
    //    rb.AddForce(transform.forward * 2);
    //}
    //else
    //{
    //    rb.AddForce(-transform.forward * 2);
    //}
    //else if (dist < 2)
    //{
    //    rb.AddForce(-transform.forward * 2);
    //}
}

