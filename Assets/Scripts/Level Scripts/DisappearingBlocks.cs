using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlocks : MonoBehaviour
{
    public float blockCount;
    GameObject pf;
    // Start is called before the first frame update
    public GameObject block;
    //space between each block
    public float offSet;
    public bool X = false;
    public bool Y = false;
    public bool Z = false;
    void Start()
    {


        StartCoroutine(spawnBlocks(blockCount));

        //if (on)
        //{
        //    StartCoroutine(spawnBlocks(blockCount));
        //}
    }

    // Update is called once per frame
    void Update()
    {


    }
    IEnumerator spawnBlocks(float blockCount)
    {

        //for (int i = 0; i < blockCount; i++)
        //{

        for (int i = 0; i < blockCount; i++)
        {


            if (X)
            {
                pf = Instantiate(block, new Vector3(this.transform.position.x - i * offSet, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                pf.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

                Destroy(pf, 6f);
                yield return new WaitForSeconds(2f);

                if (i == 4)
                {
                    StartCoroutine(spawnBlocks(blockCount));
                }
            }
            else if (Z)
            {
                pf = Instantiate(block, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + i * offSet), Quaternion.identity);
                pf.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                Destroy(pf, 5f);
                yield return new WaitForSeconds(2f);

                if (i == 4)
                {
                    StartCoroutine(spawnBlocks(blockCount));
                }
            }


        }



    }


}
