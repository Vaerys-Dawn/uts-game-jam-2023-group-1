using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource : MonoBehaviour
{

    public float startTime = 5f;
    private float counter;
    public bool isColliding;



    // Start is called before the first frame update
    void Start()
    {
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
                Destroy(gameObject);
            }
        }
        
    }

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == gameObject.tag || col.gameObject.tag == "Player") {
            Debug.Log("touching");
            isColliding = true;
            
        } 
    }

    void OnCollisionExit (Collision col) {
        isColliding = false;
    }

}
