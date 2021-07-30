using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour,ITriggerable
{
    [SerializeField] private string key;
    void Awake()
    {
        if (PlayerPrefs.GetInt(key) == 1)
        {
            GetComponent<RawImage>().enabled = true;
        }
    }
    

    public void Trigger()
    {
        GetComponent<RawImage>().enabled = true;
    }
}
