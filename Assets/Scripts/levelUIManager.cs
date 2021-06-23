using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class levelUIManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public int score = 0;
    //public int key = 1;

    // Start is called before the first frame update
    void Start()
    {
        //just update the score for now
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = score.ToString() + " / " + key;

    }
}
