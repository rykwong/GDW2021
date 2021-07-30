using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePlatform : MonoBehaviour, ITriggerable
{
    float xRotation = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Trigger()
    {
        this.transform.rotation = Quaternion.Euler(xRotation += 15.0f, 0.0f, 0.0f);
    }


}
