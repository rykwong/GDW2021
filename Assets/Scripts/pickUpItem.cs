using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach this to items needing pickup and to trigger a future event
public class pickUpItem : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            EnemyMovements.setAwaken(true);
        }

    }
}
