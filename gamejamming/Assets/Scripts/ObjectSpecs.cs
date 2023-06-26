using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpecs : MonoBehaviour {


    bool isHeld = true;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        //Disconnect check

        
        if (isHeld == false) {
            StartCoroutine(SelfDestruct());
        }
        else {
            StopCoroutine(SelfDestruct());
        }
    }

    IEnumerator SelfDestruct() {
        yield return  new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
