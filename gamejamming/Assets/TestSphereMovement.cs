using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSphereMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xInput * movementSpeed, rb.velocity.y, zInput * movementSpeed);
        
    }
}
