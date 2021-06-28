using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public CharacterController controller;
    public GameObject[] objects;
    public int maxMaterials = 100;
    public float spawnDistance = 5f;
    public int spawnCost = 10;

    private int materials;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObj();
    }

    private void SpawnObj()
    {
        Vector3 spawnPos = controller.transform.position + controller.transform.forward * spawnDistance;
        if (Input.GetButtonDown("1Key") && materials + spawnCost < maxMaterials)
        {
            Instantiate(objects[0], spawnPos, controller.transform.rotation);
            materials += spawnCost;
        }
        else if (Input.GetButtonDown("2Key") && materials + spawnCost < maxMaterials)
        {
            Instantiate(objects[1], spawnPos, controller.transform.rotation);
            materials += spawnCost;
        }
        else if(Input.GetButtonDown("3Key") && materials + spawnCost < maxMaterials)
        {
            Instantiate(objects[2], spawnPos, controller.transform.rotation);
            materials += spawnCost;
        }
        else if (Input.GetButtonDown("4Key") && materials + spawnCost < maxMaterials)
        {
            Instantiate(objects[3], spawnPos, controller.transform.rotation);
            materials += spawnCost;
        }
    }
}
