using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
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
        if (energy < 0) energy = 0;
        if (energy > maxEnergy) energy = maxEnergy;
        if (energy == 0) alive = false;
        if (energy == 10) alive = true;
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
