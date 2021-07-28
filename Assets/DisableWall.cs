using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableWall : MonoBehaviour, ITriggerable
{

    public bool on = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (on == false)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }


    public void Trigger()
    {
        on = false;
    }

}
