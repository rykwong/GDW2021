using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour,IInteractable
{
    [SerializeField] private string key;
    [SerializeField] private GameObject target;
    public void Interact()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt(key,1);
        target.GetComponent<ITriggerable>().Trigger();
        Debug.Log(PlayerPrefs.GetInt(key));
    }
}
