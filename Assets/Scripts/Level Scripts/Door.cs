using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    private SceneTransition sceneTransition;
    [SerializeField] private string scene;

    private void Start()
    {
        sceneTransition = GameObject.Find("GameManager").GetComponent<SceneTransition>();
    }

    public void Interact()
    {
        sceneTransition.Transition(scene);
    }
}
