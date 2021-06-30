using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{
    private bool LeftRightZ;

    private float EyeScanZ = 0;
    private int index = 0;

    [Header("Player Detection Variables")]
    [SerializeField] private float ViewDistance = 2f;
    [SerializeField] private Transform eyes;
    
    [Header("Patrol Variables")]
    [SerializeField] private float distanceOffset;
    [SerializeField] private float speed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private List<Transform> points = new List<Transform>();

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
            transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position,speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward,points[index].transform.position-transform.position,rotSpeed*Time.deltaTime,0.0f));
            if (Vector3.Distance(transform.position, points[index].transform.position) < distanceOffset)
            {
                index = (index + 1) % points.Count;
            }
            
        }
    }
    private void Detect()
    {
        if(LeftRightZ)
        {
            if(EyeScanZ < 30)
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
            if (EyeScanZ > -30)
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
        Debug.DrawRay(eyes.position, eyes.transform.forward * ViewDistance);
     
        if (Physics.Raycast(eyes.position, eyes.transform.forward * ViewDistance, out hit, ViewDistance))
        {
            if(hit.transform.gameObject.tag == "Player")
            {
                Debug.Log(gameObject.name + " CAN see Player");
            }
            else if(hit.transform.gameObject.tag == "Wall")
            {
                Debug.Log("Move to next point");
                index = (index + 1) % points.Count;
            }
     
        }
    }
}
