using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] Transform waypointsParent;

    [SerializeField] float travelTimeBetweenPoints = 5f;
    [SerializeField] float endPointStallTime = 3f;
    [SerializeField] float midPointStallTime = 3f;

    float dwellTimer = 0f;

    bool movingForward = true;

    int currentPointIndex = 0;

    [SerializeField] bool loopTrack;

    [SerializeField] bool stopAtEndingPointOnLoopTrack = false;

    float stoppingDistanceThreshold = 0.05f;

    float t = 0f;

    Vector3 startingPoint;
    Vector3 targetPoint;

    List<Vector3> wayPoints;

    Transform playerTransformParent;

    private void Start()
    {
        wayPoints = new List<Vector3>();

        for(int i=0; i<waypointsParent.childCount; i++)
        {
            wayPoints.Add(waypointsParent.GetChild(i).position);
        }

        if(wayPoints.Count < 1)
        {
            Debug.LogError("You need more than 1 way point to travel along");
            enabled = false;
        }

        startingPoint = GetWaypoint();
        GetNextWaypointIndex();
        targetPoint = GetWaypoint();

        transform.position = startingPoint;
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position,targetPoint) <= stoppingDistanceThreshold)
        {
            dwellTimer += Time.deltaTime;

            bool continueTrack = false;
            if (IsAtEndpoint())
            {
                if (loopTrack && !stopAtEndingPointOnLoopTrack && (currentPointIndex == wayPoints.Count - 1))
                {
                    continueTrack = true;
                }

                if(dwellTimer >= endPointStallTime)
                {
                    continueTrack = true;
                }
            }
            else
            {
                if(dwellTimer >= midPointStallTime)
                {
                    continueTrack = true;
                }
            }

            if (continueTrack)
            {
                startingPoint = targetPoint;
                GetNextWaypointIndex();
                targetPoint = GetWaypoint();

                t = 0f;
                dwellTimer = 0f;
            }

            return;
        }

        t += (Time.deltaTime / travelTimeBetweenPoints);

        transform.position = Vector3.Lerp(startingPoint, targetPoint, t);
    }

    private bool IsAtEndpoint()
    {
        if(currentPointIndex == 0 || currentPointIndex == (wayPoints.Count - 1))
        {
            return true;
        }
        return false;
    }

    private Vector3 GetWaypoint()
    {
        return wayPoints[currentPointIndex];
    }

    private void GetNextWaypointIndex()
    {
        if (!loopTrack)
        {
            if (movingForward)
            {
                currentPointIndex++;
                if (currentPointIndex >= wayPoints.Count)
                {
                    currentPointIndex = wayPoints.Count - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentPointIndex--;
                if (currentPointIndex <0)
                {
                    currentPointIndex = 1;
                    movingForward = true;
                }
            }
        }
        else
        {
            currentPointIndex++;
            if(currentPointIndex >= wayPoints.Count)
            {
                currentPointIndex = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerTransformParent = other.transform.parent;
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = playerTransformParent;
        }
    }

    private void OnDrawGizmos()
    {
        if (waypointsParent == null) return;

        Gizmos.color = Color.white;


        for(int i=0; i<waypointsParent.childCount; i++)
        {
            Gizmos.DrawSphere(waypointsParent.GetChild(i).position, 0.5f);

            int nextWaypoint = (i + 1);
            if (nextWaypoint >= waypointsParent.childCount) break;
            Gizmos.DrawLine(waypointsParent.GetChild(i).position, waypointsParent.GetChild(nextWaypoint).position);
        }
    }
}
