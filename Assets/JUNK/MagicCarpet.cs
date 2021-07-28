using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCarpet : MonoBehaviour
{
    public GameObject player;
    private int index = 0;
    private float wait;
    //private int triggers = 0;
    [SerializeField] private List<Vector3> points = new List<Vector3>();
    [SerializeField] private float speed;
    [SerializeField] private float distanceOffset;
    [SerializeField] private float initWait;
    //[SerializeField] private int triggersNeeded;
    public bool onPlatform = false;
    public bool on = false;
    private void Start()
    {
        wait = initWait;
    }

    void FixedUpdate()
    {
        if (on)
        {
            Move();
        }
    }

    private void Move()
    {

        if (points.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[index], speed * Time.deltaTime);
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


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            on = true;
            if (on)
            {
                player.transform.parent = this.transform;
                onPlatform = true;
            }



        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (onPlatform)
        {
            player.transform.parent = null;
        }
        onPlatform = false;


    }
}