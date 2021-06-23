using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//testing script
public class EnemyMovements : MonoBehaviour
{

    // Start is called before the first frame update
    public static bool awaken;
    void Start()
    {
        awaken = false;
    }

    // Update is called once per frame
    //this is the idea
    void Update()
    {
        if (awaken == true)
        {
            Debug.Log("Enemy is awake");
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
        else
        {
            Debug.Log("Enemy is asleep");
        }
    }
    public static void setAwaken(bool a)
    {
        awaken = a;
    }

}
