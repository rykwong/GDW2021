using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    //switch on or off the platform extension
    public bool growPlatform;
    public GameObject extendedPlatform;
    private GameObject square;
    //private GameObject sphere;
    private Vector3 scaleChange, xScaleChange, positionChange;
    private void Awake()
    {

        square = GameObject.CreatePrimitive(PrimitiveType.Cube);
        square.transform.position = new Vector3(extendedPlatform.transform.position.x, extendedPlatform.transform.position.y, extendedPlatform.transform.position.z);
        square.layer = 6;
        //// Create a sphere at the origin.
        ////sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ////sphere.transform.position = new Vector3(0, 0, 0);
        //extendedPlatform.transform.position = new Vector3(0, 0, 0);
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        //plane.transform.position = new Vector3(0, -0.5f, 0);

        //// Change the floor color to blue.
        //// The blue material is present in Resources and not created in this script.
        //Renderer rend = plane.GetComponent<Renderer>();
        //rend.material = Resources.Load<Material>("blue");

        scaleChange = new Vector3(0.125f, 0.125f, 0.125f);
        square.transform.localScale = scaleChange;
        square.transform.parent = extendedPlatform.transform;
        xScaleChange = new Vector3(0.004f, 0, 0);
        positionChange = new Vector3(0.001f, 0, 0);
        //positionChange = new Vector3(0.0f, -0.005f, 0.0f);

    }
    private void Start()
    {
        growPlatform = false;
        //    extendedPlatform = GameObject.Find("ExtendedPlatform");
        //    Debug.Log("POSITION:" + extendedPlatform.transform.position);
    }
    private void Update()
    {
        Debug.Log("GROW PLATFORM:" + growPlatform);
        //if (growPlatform == true)
        //{
        if (growPlatform == true)
        {
            scalePlatform();
        }
        //}
        //square.transform.localScale += xChange;
        //square.transform.position += positionChange;
        //square.transform.localScale += scaleChange;
        //square.transform.position += positionChange;

        //// Move upwards when the sphere hits the floor or downwards
        //// when the sphere scale extends 1.0f.
        //if (square.transform.localScale.y < 0.1f || square.transform.localScale.y > 1.0f)
        //{
        //    scaleChange = -scaleChange;
        //    positionChange = -positionChange;
        //} 

    }

    private void scalePlatform()
    {
        //Debug.Log("SQUARE LOCAL SCALE:" + square.transform.localScale);
        //Debug.Log("SQUARE POSITION:" + square.transform.position);
        square.transform.localScale += xScaleChange;
        square.transform.position += positionChange;
    }
    public void setExtendPlatform(bool gp)
    {
        this.growPlatform = gp;
    }
}
