using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 50.0f;
    public float maxSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Cursor.lockState = Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = Cursor.lockState = CursorLockMode.None;

        if (Input.GetKey(KeyCode.W)){
            rb.AddForce(new Vector3(0, 0, thrust));
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-thrust, 0, 0));
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -thrust));
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(thrust, 0, 0));
        }

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));
    }
}
