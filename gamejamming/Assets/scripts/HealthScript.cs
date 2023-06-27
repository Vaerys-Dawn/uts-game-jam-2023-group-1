using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HealthScript : NetworkBehaviour
{
    // Start is called before the first frame update

    public int energy;
    public Rigidbody rigid;
    public bool charging = false;
    public bool slowcharge = false;
    public int chargeTime = 2;
    public int maxEnergy = 10;
    public int slowchargeMult = 2;
    public bool alive = true;
    private int nextUpdate = 1;

    //Animator
    [SerializeField] private Animator robotAnimator;
    [SerializeField] private float animTime;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        energy = maxEnergy;
    }

    public void Update()
    {
        int chargeRate = chargeTime;
        if (slowcharge)
        {
            chargeRate *= slowchargeMult;
        }
        // If the next update is reached
        if (Time.time >= nextUpdate)
        {      
            nextUpdate = Mathf.FloorToInt(Time.time) + chargeRate;
            AddCharge();
        }
    }

    public void AddCharge()
    {
        if (charging)
        {
            print("Helo");
            energy++;
            ClampEnergy();
        }
    }

    public void RemoveCharge()
    {
        // todo play remove charge sound
        energy--;
        ClampEnergy();
    }

    private void ClampEnergy()
    {
        if (energy < 0) 
        { 
            energy = 0;
            robotAnimator.SetBool("isFalling", true);
            StartCoroutine(StopFallAnimation());
        
        }
        if (energy > maxEnergy) energy = maxEnergy;
        if (energy == 0)
        {
            alive = false;
            rigid.velocity.Set(0, 0, 0);
        }
        if (energy == 10) alive = true;
    }


    IEnumerator StopFallAnimation() 
    {
        yield return new WaitForSeconds(animTime);
        robotAnimator.SetBool("isFalling", false);
    
    
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "ChargeBay")
        {
            charging = true;
        }
        if (collider.tag == "SlowChargeBay")
        {
            charging = true;
            slowcharge = true;
        }

        if (collider.tag == "Door")
        {
            print("door found");
            doorHandler handler = collider.GetComponent<doorHandler>();
            if (handler.IsClosed())
            {
                if (handler.jam)
                {
                    RemoveCharge();
                }
                handler.OpenDoor();
                RemoveCharge();
            }

        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "ChargeBay")
        {
            charging = false;
        }
        if (collider.tag == "SlowChargeBay")
        {
            charging = false;
            slowcharge = false;
        }
    }
}
