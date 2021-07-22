using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    private SceneTransition sceneTransition;
    [SerializeField] private string scene;
    [SerializeField] private Vector3 pos;
    [SerializeField] private bool loadCoords;

    private void Start()
    {
        sceneTransition = GameObject.Find("GameManager").GetComponent<SceneTransition>();
    }

    public void Interact()
    {
        if (loadCoords)
        {
            PlayerPrefs.SetFloat("X", pos.x);
            PlayerPrefs.SetFloat("Y", pos.y);
            PlayerPrefs.SetFloat("Z", pos.z);
        }
        sceneTransition.Transition(scene);
    }
}
