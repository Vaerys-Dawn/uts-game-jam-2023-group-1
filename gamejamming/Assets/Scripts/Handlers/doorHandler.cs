using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class doorHandler : NetworkBehaviour
{

    public bool jam = false;
    public AudioSource doorSound;
    public AudioClip open;
    public AudioClip close;
    private bool isOpen = false;
    int closeTime = 90;
    int closeCounter = 0;
    SkinnedMeshRenderer renderer;
    private float lerpPoint= 0.5f;
    float lerpTime = 0;
    float lerpNow = 100;

    public void Start()
    {
        renderer = GetComponent<SkinnedMeshRenderer>();
    }
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
        lerpNow = Mathf.Lerp(isOpen ? 0 : 100, isOpen ? 100 : 0, lerpTime/lerpPoint);
        lerpTime += Time.deltaTime;
        renderer.SetBlendShapeWeight(0, lerpNow);
        
        if (closeCounter > 0)
        {
            closeCounter--;
        }
        else if (closeCounter == 0 && isOpen)       
        {
            CloseDoor();
  
        }
    }

    private void CloseDoor()
    {
        doorSound.clip = close;
        doorSound.Play();
        lerpTime = 0;
        // todo close animation
        // todo change collision shape
        isOpen = false;
        // todo if jam spawn jammed stuff
    }

    public void OpenDoor()
    {
        // todo door animation
        // todo change colision shape
        lerpTime = 0;
        if (jam)
        {
            jam = false;
            // todo remove jammed stuff
        }
        doorSound.clip = open;
        doorSound.Play();
        closeCounter = closeTime;
        isOpen = true;
    }

    public bool IsClosed()
    {
        return !isOpen;
    }
}
