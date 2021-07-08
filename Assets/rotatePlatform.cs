using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlatform : MonoBehaviour
{
    // Start is called before the first frame update

    //Transform rotation;
    public float speed = 1.0f;
    public float maxRotation = 30.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.rotation = Quaternion.Euler(0.0f, maxRotation * Mathf.Sin(Time.time * speed), 0.0f);
    }


}
