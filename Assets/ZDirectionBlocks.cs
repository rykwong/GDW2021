using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZDirectionBlocks : MonoBehaviour
{
    public float blockCount;
    GameObject pf;
    // Start is called before the first frame update
    public GameObject block;
    public float offSet;
    bool restart;
    void Start()
    {
        StartCoroutine(spawnBlocks(blockCount));
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

            pf = Instantiate(block, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - i * offSet), Quaternion.identity);
            pf.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            Destroy(pf, 5f);
            yield return new WaitForSeconds(2f);
            if (i == 4)
            {
                StartCoroutine(spawnBlocks(blockCount));
            }
        }



    }
}
