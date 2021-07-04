using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Lever lever1;
    [SerializeField] private Lever lever2;

    [SerializeField] private GameObject openDoor;
    // Update is called once per frame
    void Update()
    {
        CheckLever();
    }

    private void CheckLever()
    {
        if (lever1.on && lever2.on)
        {
            Debug.Log("Door open");
            gameObject.SetActive(false);
        }
    }
}
