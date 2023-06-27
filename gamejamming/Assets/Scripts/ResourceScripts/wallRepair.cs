using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallRepair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider col) {
        if (col.gameObject.tag == gameObject.tag) {
            Debug.Log("Collision Detected");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
