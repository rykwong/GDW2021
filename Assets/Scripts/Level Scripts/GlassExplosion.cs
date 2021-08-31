using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassExplosion : MonoBehaviour, ITriggerable
{
    // Start is called before the first frame update
    /*
     * Attach this script to any object you want to explode
     * Trigger for explosion is an object with the tag "Player"
     */

    [SerializeField] private bool on;
    public float cubeSize;
    public int cubesInRow = 5;
    float cubePivotDistance;
    Vector3 cubePivot;
    public bool makePickable = false;


    public float time = 10;
    public float explosionRadius;
    public float explosionForce;
    public float explosionUpward;
    public bool destroy = false;
    void Start()
    {
        //what does this do?

        //calculate pivot distance???
        cubePivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector???
        cubePivot = new Vector3(cubePivotDistance, cubePivotDistance, cubePivotDistance);


    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            explode();
        }
    }

    public void explode()
    {
        gameObject.SetActive(false);
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosive force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }
    //what does this do? 
    void createPiece(int x, int y, int z)
    {
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //set the piece position and scale

        //all the pieces will be 0.5 units apart and equal distance?
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubePivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        //piece.GetComponent<BoxCollider>().enabled = false;
        //add rigidbody and set mass
        //why?
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.GetComponent<Renderer>().material.color = Color.black;

        if (destroy)
        {
            Destroy(piece, time);
        }
        if (makePickable)
        {
            piece.tag = "Pickable";
            piece.layer = 6;
        }




    }

    public void Trigger()
    {
        on = true;

    }


}
