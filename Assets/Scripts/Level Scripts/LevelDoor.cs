using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour, IInteractable
{
    private SceneTransition sceneTransition;
    private GameObject player;
    [SerializeField] private string scene;

    private void Start()
    {
        sceneTransition = GameObject.Find("GameManager").GetComponent<SceneTransition>();
        player = GameObject.Find("Player");
    }

    public void Interact()
    {
        PlayerPrefs.SetFloat("X", player.transform.position.x);
        PlayerPrefs.SetFloat("Y", player.transform.position.y);
        PlayerPrefs.SetFloat("Z", player.transform.position.z);
        sceneTransition.Transition(scene);
    }
}
