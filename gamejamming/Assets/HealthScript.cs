using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update

    private int energy;
    public Rigidbody rigid;
    public bool charging = false;
    public bool slowcharge = false;
    public int chargeTime = 10;
    public int maxEnergy = 10;
    public int slowchargeMult = 2;
    public bool alive = true;

    private void Awake()
    {
        energy = 10;
    }

    private void FixedUpdate()
    {
        int ChargeRate = chargeTime;
        if (slowcharge)
        {
            ChargeRate *= slowchargeMult;
        }
        if (Time.fixedDeltaTime % chargeTime == 0 && charging)
        {
            energy++;
            ClampEnergy();
        }
    }

    public void RemoveCharge()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "ChargeBay")
        {
            charging = true;
        }
        if (collision.collider.tag == "SlowChargeBay")
        {
            charging = true;
            slowcharge = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "ChargeBay")
        {
            charging = false;
        }
        if (collision.collider.tag == "SlowChargeBay")
        {
            charging = false;
            slowcharge = false;
        }
    }
}
