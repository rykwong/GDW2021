using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollBall : MonoBehaviour
{
    // Start is called before the first frame update
    float acceleration;
    void Start()
    {
        acceleration = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Physics.gravity * 10, ForceMode.Acceleration);
        rigidbody.AddForce(new Vector3(0, 0, acceleration += 0.5f));



    }
}
