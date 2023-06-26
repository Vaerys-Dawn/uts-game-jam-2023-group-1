using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestSphereMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 lookAngle = new Vector3(60, 0, 0);
    [SerializeField] private Vector3 lookPosition = new Vector3(0, 20, -10);
    // Start is called before the first frame update

    public static List<TestSphereMovement> players = new List<TestSphereMovement>();

    void Awake()
    {
        players.Add(this);
        transform.position.Set(1.1f, transform.position.y, transform.position.z);
        PlayerInput network = GetComponent<PlayerInput>();
        if (network != null)
        {
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
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector3(xInput * movementSpeed, rb.velocity.y, zInput * movementSpeed);

    }
}
