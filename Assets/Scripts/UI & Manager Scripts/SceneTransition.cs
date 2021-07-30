using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void Transition(string scene)
    {
        PauseMenu.gameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void SetTransition(string sceneSelect)
    {
        Vector3 pos = Vector3.zero;
        string scene = "";
        if (sceneSelect == "Limbo")
        {
            scene = "Limbo";
        }
        else if (sceneSelect == "Platform1")
        {
            scene = "Thomas2";
        }
        else if (sceneSelect == "Platform2")
        {
            scene = "EasyLevel";
        }
        else if (sceneSelect == "Heaven1")
        {
            pos = new Vector3(0, 3, -115);
            scene = "Heaven1";
        }
        else if (sceneSelect == "Heaven2")
        {
            pos = new Vector3(0, 3, -20);
            scene = "Heaven1";
        }
        else if (sceneSelect == "Heaven3")
        {
            pos = new Vector3(0, 43, 190);
            scene = "Heaven1";
        }
        else if (sceneSelect == "Puzzle1")
        {
            scene = "Koshi";
        }

        if (pos != Vector3.zero)
        {
            PlayerPrefs.SetFloat("X", pos.x);
            PlayerPrefs.SetFloat("Y", pos.y);
            PlayerPrefs.SetFloat("Z", pos.z);
        }
        Transition(scene);
    }
}
