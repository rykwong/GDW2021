using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeper : MonoBehaviour
{

    /*
     * Note: This is for a square matrix
     */



    // Start is called before the first frame update

    //object we will use to instantiate
    public GameObject box;



    //check the player's position???
    public GameObject player;

    //temporary variable for instantiated variables
    GameObject pf;

    //space between the blocks
    public float offset;
    //size of blocks, but I dont think im going to use this.
    public float scale;
    //size of my matrix
    public float row, columns;
    //sizes for the 2d array
    [SerializeField] private Material highlightMaterial;
    //2d array
    //persist the instantiated cubes
    List<GameObject> square = new List<GameObject>();
    //List<Vector3> bombPositions;

    float randomNumber;
    //float distanceFromBomb;
    float distanceBetween;

    Vector3 currentPosition;



    float zCount = 40;
    Vector3[,,] blockPositions = new Vector3[5, 5, 5];
    void Start()
    {


        BlockField(row, columns);


    }

    // Update is called once per frame
    void Update()
    {


        //squareCollection = new List<GameObject>();
        //for (int i = 0; i < squareCollection.Count; i++)
        //{
        //    Debug.Log("BLOCK POSITION: " + squareCollection.ElementAt(i).transform.position);
        //}F
        //if (box != null)
        //{
        //    scale = box.GetComponent<Transform>().localScale.x;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    //StartCoroutine(createMineField(5));
        //Debug.Log("Collection of bombs size:" + bombPositions.Capacity);
        //checkDistance();

        //printBoxPositions();  
        //}
    }


    //IEnumerator createMineField(float n)
    //{
    //    for (int i = 0; i < n; i++)
    //    {
    //        for (int j = 0; j < n; j++)
    //        {
    //            pf = Instantiate(box, new Vector3(i * offset, 0, j * offset), Quaternion.identity);
    //            //Destroy(pf, 5f);
    //            //yield return new WaitForSeconds(2f);

    //        }
    //    }
    //}

    void BlockField(float row, float column)
    {
        for (int i = 0; i < column; i++)
        {
            for (int j = 0; j < row; j++)
            {
                pf = Instantiate(box, new Vector3(i * offset, 0, j * offset), Quaternion.identity);

                pf.transform.parent = this.transform;
                pf.transform.localScale = new Vector3(1, 1, 1);


            }
        }

    }
    /*
     *go by 3 columns per row 
     * 
     */
    void changeColors()
    {
        //increment through the array
        for (int i = 0; i < square.Count; i++)
        {
            //create a for loop to add to the x  coordinate

        }
    }




    //void createMineField(float row, float column)
    //{
    //    for (int i = 0; i < column; i++)
    //    {
    //        for (int j = 0; j < row; j++)
    //        {
    //            randomNumber = Random.Range(0f, 1f);
    //            if (randomNumber > 0.5)
    //            {
    //                //create my squares
    //                pf = Instantiate(box, new Vector3(i * offset, 0, j * offset), Quaternion.identity);

    //                //squareCollection.Add(pf);
    //                //after creation, persist these cubes

    //                //Debug.Log("PARENT:" + pf.transform.parent);
    //                pf.transform.parent = this.transform;
    //                //flatten my squares
    //                pf.transform.localScale = new Vector3(1, 0.5f, 1);

    //                //give my instantiated object a bomb tag
    //                pf.tag = "bomb";
    //                //turn it black
    //                square.Add(pf);
    //                var selectionRenderer = pf.GetComponent<Renderer>();

    //                if (selectionRenderer != null)
    //                {
    //                    selectionRenderer.material = highlightMaterial;
    //                }



    //                //store the positions in another 2d Arraty
    //                //Debug.Log("BOMB POSITION:" + pf.transform.localPosition);

    //                //bombPositions.Add(pf.transform.position);

    //            }



    //            else
    //            {

    //                pf = Instantiate(box, new Vector3(i * offset, 0, j * offset), Quaternion.identity);

    //                //Debug.Log("PARENT:" + pf.transform.parent);
    //                pf.transform.parent = this.transform;
    //                pf.transform.localScale = new Vector3(1, 0.5f, 1);
    //                pf.tag = "tile";
    //                //square.Add(pf);
    //                //Debug.Log("TILE POSITION:" + pf.transform.localPosition);
    //            }
    //            //Debug.Log("NUMBER: " + Random.Range(0f, 1f));
    //            //PLACE INTO AN IF STATEMENT


    //            //pf = Instantiate(box, new Vector3(i * offset, 0, j * offset), Quaternion.identity);

    //            //var selectionRenderer = pf.GetComponent<Renderer>();
    //            //if (selectionRenderer != null)
    //            //{
    //            //    selectionRenderer.material = highlightMaterial;
    //            //}
    //            //boxPositions[i, j] = pf.transform.position;

    //            //PLACE INTO AN IF STATEMENT
    //            //Debug.Log("POSITION:" + pf.transform.position);
    //            //Destroy(pf, 5f);
    //            //yield return new WaitForSeconds(2f);

    //        }
    //    }
    //}


}
