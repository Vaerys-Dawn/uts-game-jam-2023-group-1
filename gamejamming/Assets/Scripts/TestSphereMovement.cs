using System.Collections.Generic;
using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestSphereMovement : NetworkBehaviour
{
    public AudioSource step;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 lookAngle = new Vector3(60, 0, 0);
    [SerializeField] private Vector3 lookPosition = new Vector3(0, 20, -10);

    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject robotModel;
    private HealthScript healthScript;
    bool enableInput = false;
    int coolDown = 0;
    // Start is called before the first frame update

    public static List<TestSphereMovement> players = new List<TestSphereMovement>();

    public override void OnNetworkSpawn()
    {
        players.Add(this);
        healthScript = GetComponent<HealthScript>();

   
        if (IsOwner && IsClient)
        {
            enableInput = true;
            print("Network Found");
            Camera[] cameras = FindObjectsOfType<Camera>();
            if (cameras.Length > 0)
            {
                Camera cam = cameras[0];
                print("attaching Camera");
                cam.transform.position = lookPosition;
                cam.transform.rotation = Quaternion.Euler(lookAngle.x, lookAngle.y, lookAngle.z);
                cam.transform.SetParent(this.transform, false);
            }
            
        }
    }

    private void OnDestroy()
    {
        players.Remove(this);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!healthScript.alive) rb.velocity = Vector3.zero;
        if (!enableInput || !healthScript.alive) { return; }
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");
<<<<<<< Updated upstream:gamejamming/Assets/Scripts/TestSphereMovement.cs
        rb.velocity = new Vector3(xInput, rb.velocity.y, zInput).normalized * movementSpeed;

		bool playerHasHorizontalSpeed = Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            playerAnimator.SetBool("isWalking", true);

        }

        else 
        {

            playerAnimator.SetBool("isWalking", false);
        
        }

        //Rotate in Direction of Movement
        if (rb.velocity.magnitude != 0) 
        {

            robotModel.transform.rotation = Quaternion.Lerp(robotModel.transform.rotation, Quaternion.LookRotation(rb.velocity), 2f);
        
        }

	}
=======
        rb.velocity = new Vector3(xInput * movementSpeed, rb.velocity.y, zInput * movementSpeed);
        if (coolDown <= 0)
        { 
            if (rb.velocity.x > 0.2f || rb.velocity.z > 0.2f || rb.velocity.x < -0.2f || rb.velocity.z < -0.2f)
            {
                step.Play();
                coolDown = 8;
            }
        }
        coolDown--;
    }
>>>>>>> Stashed changes:gamejamming/Assets/TestSphereMovement.cs
}
