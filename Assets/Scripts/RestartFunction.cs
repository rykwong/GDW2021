using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//note this should only happen based on the number of lives a player has.
//an object attached with this will trigger the restart function
public class RestartFunction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //reload the current scene

            SceneManager.LoadScene(0);
        }
    }
}
