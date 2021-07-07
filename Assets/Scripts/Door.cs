using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{

    [SerializeField] private string scene;
    public void Interact()
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
