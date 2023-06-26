using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunHandler : MonoBehaviour
{
	
	private int ammo = 0;
	public int reload;

	RaycastHit hit;

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "ammo"){
			ammo = reload;
			Destroy(collider.gameObject);
		}
	}

	void Start(){
		//SEND HELP
	}

	void FixedUpdate(){

		if(Input.GetKeyDown("Space")){
			if(Physics.Raycast(transform.position, transform.forward, out hit, 10)){
				//add effects here
				//hit.collider.gameObject.damage();
			}	
		}
	}
}