using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *How to use this script:
 *  the moving platform takes these objects:
 *      Player
 *        empty object 1 called point1
 *        empty object 2 called point2
 *       
 *     set how many points you want to move between
 */
public class MovingPlatform : MonoBehaviour, ITriggerable
{
    private int index = 0;
    private float wait;
    private int triggers = 0;
    [SerializeField] private List<Vector3> points = new List<Vector3>();
    [SerializeField] private float speed;
    [SerializeField] private float distanceOffset;
    [SerializeField] private float initWait;
    [SerializeField] private int triggersNeeded;
    


    private void Start()
    {
        wait = initWait;

    }

    void FixedUpdate()
    {
        if(triggers == triggersNeeded) Move();
    }

    private void Move()
    {

        if (points.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[index],speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[index]) < distanceOffset)
            {
                if (wait <= 0)
                {
                    index = (index + 1) % points.Count;
                    wait = initWait;
                }
                else
                {
                    wait -= Time.deltaTime;
                }
            }
        }
    }

    public void Trigger()
    {
        triggers++;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}


