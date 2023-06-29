using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class resourceDropoff : NetworkBehaviour
{

    public int Value = 0;
    public bool pickup = true;
    [SerializeField] resourceSpawner.ResourceType type;
    private string tag;


    // Start is called before the first frame update
    void Start()
    {
        tag = resourceSpawner.getResourceTag(this.type);
        switch (tag) {
            case "Ammo":
                //red
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                break;
            case "Fuel":
                //Yellow
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case "Repair":
                //Green
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag(tag) && pickup) {
            Debug.Log("Collision Detected");
            Destroy(col.transform.parent.gameObject);
            Value++;
            Debug.Log("Value = " + Value);
        }
    }
}
