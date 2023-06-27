using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceDropoff : MonoBehaviour
{

    public int Value = 0;
    public bool pickup = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == gameObject.tag && pickup) {
            Debug.Log("Collision Detected");
            Destroy(col.gameObject);
            Value++;
            Debug.Log("Value = " + Value);
        }
    }
}
