using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorHandler : MonoBehaviour
{

    public bool jam = false;
    private bool isOpen = false;
    int closeTime = 90;
    int closeCounter = 0;


    public void JamDoor()
    {
        if (isOpen && !jam)
        { 
            jam = true;
            closeCounter = 0;
            CloseDoor();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (closeCounter > 0)
        {
            closeCounter--;
        }
        else if (closeCounter == 0)
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        // todo close animation
        // todo change collision shape
        isOpen = false;
        // todo if jam spawn jammed stuff
    }

    public void OpenDoor()
    {
        // todo door animation
        // todo change colision shape
        if (jam)
        {
            jam = false;
            // todo remove jammed stuff
        }
        closeCounter = closeTime;
        isOpen = true;
    }

    public bool IsClosed()
    {
        return !isOpen;
    }
}