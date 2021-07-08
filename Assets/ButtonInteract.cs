using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is a fucking mess
 * 
 * Overview of the script:
 *  growPlatform script
 *  This script is meant to extend the platform
 *  
 *  so... here is the logic
 *  
 *  growPlatform = false 
 *              ------------->
 *                              if the player's trigger encounters the button's trigger.... set growingPlatform to true
 *                                                                          --------------------> if growing platform is true
 *                                                                                                                              -----------> scale platform
 */
public class ButtonInteract : MonoBehaviour
{
    //switch on or off the platform extension
    public bool growPlatform = false;
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
    private void Update()
    {
        if (growPlatform)
        {
            scalePlatform();
        }
    }


    //create the growing platform
    public void scalePlatform()
    {
        //Debug.Log("SQUARE LOCAL SCALE:" + square.transform.localScale);
        //Debug.Log("SQUARE POSITION:" + square.transform.position);
        square.transform.localScale += xScaleChange;
        square.transform.position += positionChange;
    }
    public void setGrowPlatForm()
    {
        growPlatform = true;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Player")
        {
            Debug.Log("Player has collided");
            setGrowPlatForm();


        }
    }

}
