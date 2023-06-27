using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHandler : MonoBehaviour
{

    public bool jam = false;

    private bool toClose = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jam)
        {
            //jam door
        }

        //player unjams door

        if(toClose) //&& door fully opened
        {
            //close door fully
            toClose = false;
        }
    }

    void OnTriggerEnter()
    {
        //open fully
    }

    void OnTriggerExit()
    {
        toClose = true;
    }
}
