using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBridge : MonoBehaviour, ITriggerable
{
    [SerializeField] private bool on;
    //public GameObject block;
    GameObject pf;
    // Start is called before the first frame update
    void Start()
    {
        if (on)
        {
            spawnBridge();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Trigger()
    {
        on = true;
        this.enabled = true;
    }
    public void spawnBridge()
    {

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        pf = Instantiate(cube, new Vector3(/*1, 1, 1*//*-35.98f, 35.33f, 241.81f*/
            this.transform.position.x, this.transform.position.y, this.transform.position.z),
            Quaternion.identity);
        pf.AddComponent<Rigidbody>();
        pf.layer = 6;
        pf.transform.localScale = new Vector3(1.0f, 30.0f, 1.0f);
        pf.transform.eulerAngles = new Vector3(0, 0, 92.1f);
        //pf.GetComponent<Rigidbody>().isKinematic = true;
        //pf.transform.parent = this.transform;
        //cube.transform.localScale = new Vector3(0.125f, 6, 2.0f);
    }
}

//scale for bridge
//X 0.125, y = 6, z = 2