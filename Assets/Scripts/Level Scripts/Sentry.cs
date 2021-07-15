using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{
    private bool LeftRightZ;

    private float EyeScanZ = 0;
    private int index = 0;
    private Vector3 initPos;

    [Header("Player Detection Variables")]
    [SerializeField] private float ViewDistance = 2f;
    [SerializeField] private Transform eyes;
    [SerializeField] private LineRenderer line;
    [SerializeField] private Vector3 spawnpoint;
    [SerializeField] private int detectRange;
    
    [Header("Patrol Variables")]
    [SerializeField] private float distanceOffset;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private List<Vector3> points = new List<Vector3>();

    private void Start()
    {
        initPos = line.GetPosition(1);
        line.SetPosition(1,initPos*ViewDistance);
    }

    // Update is called once per frame
    void Update()
    {
        Detect();
        Patrol();
    }

    private void Patrol()
    {
        if (points.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[index],speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,points[index]-transform.position,rotSpeed*Time.deltaTime,0.0f));
            if (Vector3.Distance(transform.position, points[index]) < distanceOffset)
            {
                index = (index + 1) % points.Count;
            }
        }
    }
    private void Detect()
    {
        if(LeftRightZ)
        {
            if(EyeScanZ < detectRange)
            {
                EyeScanZ += 100 * Time.deltaTime;
            }
            else
            {
                LeftRightZ = false;
            }
        }
        else
        {
            if (EyeScanZ > -detectRange)
            {
                EyeScanZ -= 100 * Time.deltaTime;
            }
            else
            {
                LeftRightZ = true;
            }
        }
        eyes.transform.localEulerAngles = new Vector3(0, EyeScanZ);
     
     
        RaycastHit hit;
        // Debug.DrawRay(eyes.position, eyes.transform.forward * ViewDistance);
        if (Physics.Raycast(eyes.position, eyes.transform.forward * ViewDistance, out hit, ViewDistance))
        {
            if(hit.transform.gameObject.CompareTag("Player"))
            {
                // Debug.Log(gameObject.name + " CAN see Player");
                hit.transform.position = spawnpoint;
            }
            // else if(hit.transform.gameObject.CompareTag("Ground"))
            // {
            //     Debug.Log("Move to next point");
            //     index = (index + 1) % points.Count;
            // }
        }
    }
}
