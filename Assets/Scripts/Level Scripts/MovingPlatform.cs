using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour,ITriggerable
{
    private int index = 0;
    private float wait;
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private float speed;
    [SerializeField] private float distanceOffset;
    [SerializeField] private float initWait;
    [SerializeField] private bool on;

    private void Start()
    {
        wait = initWait;
    }

    void FixedUpdate()
    {
        if(on) Move();
    }

    private void Move()
    {
        if (points.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position,speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[index].transform.position) < distanceOffset)
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
        on = true;
    }
}
