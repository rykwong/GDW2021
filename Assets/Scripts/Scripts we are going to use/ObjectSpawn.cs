using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSpawn : MonoBehaviour
{
    public CharacterController controller;
    public GameObject[] objects;
    public int maxMana = 100;
    public float spawnDistance = 5f;
    public int spawnCost = 10;
    public Slider slider;

    private int sliderVal;

    void Start()
    {
        sliderVal = maxMana;
        slider.value = sliderVal;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObj();
    }

    private void SpawnObj()
    {
        Vector3 spawnPos = controller.transform.position + controller.transform.forward * spawnDistance;
        if (Input.GetButtonDown("1Key") && sliderVal - spawnCost >= 0)
        {
            Instantiate(objects[0], spawnPos, controller.transform.rotation);
            sliderVal -= spawnCost;
            slider.value = sliderVal;
        }
        else if (Input.GetButtonDown("2Key") && sliderVal - spawnCost >= 0)
        {
            Instantiate(objects[1], spawnPos, controller.transform.rotation);
            sliderVal -= spawnCost;
            slider.value = sliderVal;
        }
        else if(Input.GetButtonDown("3Key") && sliderVal - spawnCost >= 0)
        {
            Instantiate(objects[2], spawnPos, controller.transform.rotation);
            sliderVal -= spawnCost;
            slider.value = sliderVal;
        }
        else if (Input.GetButtonDown("4Key") && sliderVal - spawnCost >= 0)
        {
            Instantiate(objects[3], spawnPos, controller.transform.rotation);
            sliderVal -= spawnCost;
            slider.value = sliderVal;
        }
    }
}
