using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHandler : MonoBehaviour
{

	public GameObject refillFrom;
    private resourceDropoff dropzone;
	
	private int ammo = 0;
	public int maxAmmo = 5;
	public int shotCooldown = 5;
	public float counter;

	void Start(){
		dropzone = refillFrom.GetComponent<resourceDropoff>();
		counter = shotCooldown;
		//SEND HELP
	}

	void FixedUpdate(){

		if(ammo > 0)
		{
			counter -= Time.deltaTime;
		}

		if (counter <= 0)
		{
			//shoot her
			ammo--;
			counter = shotCooldown;
		}

		if (ammo >= maxAmmo) {
            dropzone.Value = -1;
        }
        if(dropzone.Value > 0) {
            dropzone.Value--;
            ammo++;
        }
	}
}