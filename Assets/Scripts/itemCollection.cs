using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollection : MonoBehaviour
{
    private GameObject collider;
    private GameObject scoreManager;
    // Start is called before the first frame update
    private void Awake()
    {
        //scoreManager = GameObject.Find("Canvas");
    }


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            //if (scoreManager != null)
            //{
            //    scoreManager.GetComponent<levelUIManager>().score++;
            //}
            Debug.Log("Player has collided");
            Destroy(gameObject);

            //after destroying the object, this should trigger an event to happen. 
        }




    }
}
