using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class resource : NetworkBehaviour
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
    void FixedUpdate()
    {
        if (transform.position.y < -10) Destroy(this.transform.parent.gameObject);
        if (isColliding) { return; }
        else {
            counter -= Time.deltaTime;

            if (counter <= 0) {
                Destroy(this.transform.parent.gameObject);
            }
        }
        
    }

    private void OnTriggerStay(Collider col)
    {
        isColliding = col.CompareTag("Spawner") || col.CompareTag("Player");
    }

}
