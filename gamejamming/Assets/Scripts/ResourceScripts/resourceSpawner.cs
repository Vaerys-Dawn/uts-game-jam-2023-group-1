using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceSpawner : MonoBehaviour
{


    public static float dropHeight = 5f;
    public Vector3 spawnOffset = new Vector3(0, dropHeight, 0);
    public GameObject resource;

    public float startTime = 5f;
    private float counter;
    public bool isColliding;


    // Start is called before the first frame update
    void Start()
    {
        spawnResource();
        counter = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isColliding) {
            counter = startTime;
        }

        else {
            counter -= Time.deltaTime;

            if (counter <= 0) {
                spawnResource();
            }
        }
    }

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == gameObject.tag || col.gameObject.tag == "Player") {
            Debug.Log("spawned");
            isColliding = true;
            
        }
    }

    void OnCollisionExit (Collision col) { 
        if (col.gameObject.tag == gameObject.tag) {
            isColliding = false;
        }
        
    }

    void spawnResource() {
        counter = startTime;
        GameObject resourceGO = (GameObject)Instantiate(resource, spawnOffset + transform.position, Quaternion.identity);
        resourceGO.tag = gameObject.tag;
        string resourceType = resourceGO.tag;
        switch (resourceType) {
            case "Ammo":
                //red
                resourceGO.GetComponent<Renderer>().material.color = Color.red;
                break;
            case "Fuel":
                //Yellow
                resourceGO.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case "Repair":
                //Green
                resourceGO.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
    }
}
