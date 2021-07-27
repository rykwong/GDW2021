using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour, ITriggerable
{
    // Start is called before the first frame update
    [SerializeField] private bool on = false;
    //[SerializeField] private float scaleX = 0.0f, scaleY = 0.0f, scaleZ = 0.0f;
    public GameObject pf;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            spawnBlocks();

        }
        on = false;

    }

    public void Trigger()
    {
        on = true;
    }
    public void spawnBlocks()
    {
        Instantiate(pf, new Vector3(/*1, 1, 1*//*-35.98f, 35.33f, 241.81f*/
             this.transform.position.x, this.transform.position.y, this.transform.position.z),
             Quaternion.identity);

    }
}
