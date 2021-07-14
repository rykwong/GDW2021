using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LoopingPlatform : MonoBehaviour
{
     
    private int index = 0;
    [SerializeField] private List<Vector3> points = new List<Vector3>();
    [SerializeField] private float speed;
    [SerializeField] private float distanceOffset;
    [SerializeField] private int startIndex;
    private void Start()
    {
        index = startIndex;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (points.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[index],speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, points[index]) < distanceOffset)
            {
                index++;
                if (index == points.Count)
                {
                    index = 0;
                    transform.position = points[index];
                }
            }
        }
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
