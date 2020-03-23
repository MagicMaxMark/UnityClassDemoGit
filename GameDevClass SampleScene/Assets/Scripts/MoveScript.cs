using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust = 50.0f;
    public float maxSpeed = 2.0f;

    public int goingForward = 0; //0 is null, 1 is true, 2 is false
    public int goingLeft = 0; //0 is null, 1 is true, 2 is false

    public Transform playerBody;
    public float mouseSensitivity;

    float xAxisClamp = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = Cursor.lockState = CursorLockMode.None;

        goingForward = 0;
        goingLeft = 0;

        //if gets input and turns it into variables
        if (Input.GetKey(KeyCode.W))
        {
            goingForward = 1;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            goingForward = 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            goingLeft = 1;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            goingLeft = 2;
        }

        //uses variables to determine movement
        if (goingForward == 0)
        {
            if (goingLeft == 1)
            {
                rb.AddForce(transform.right * -thrust);
            }

            else if (goingLeft == 2)
            {
                rb.AddForce(transform.right * thrust);
            }
        }

        else if (goingForward == 1)
        {
            if (goingLeft == 0)
            {
                rb.AddForce(transform.forward * thrust);
            }

            else if (goingLeft == 1)
            {
                rb.AddForce(transform.forward * thrust / 2);
                rb.AddForce(transform.right * -thrust / 2);
            }

            else if (goingLeft == 2)
            {
                rb.AddForce(transform.forward * thrust / 2);
                rb.AddForce(transform.right * thrust / 2);
            }
        }

        else if (goingForward == 2)
        {
            if (goingLeft == 0)
            {
                rb.AddForce(transform.forward * -thrust);
            }

            else if (goingLeft == 1)
            {
                rb.AddForce(transform.forward * -thrust / 2);
                rb.AddForce(transform.right * -thrust / 2);
            }

            else if (goingLeft == 2)
            {
                rb.AddForce(transform.forward * -thrust / 2);
                rb.AddForce(transform.right * thrust / 2);
            }
        }

        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed));
    }

    void RotateCamera()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = MouseX * mouseSensitivity;
        float rotAmountY = MouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotBody.y += rotAmountX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }


        transform.rotation = Quaternion.Euler(targetRotCam);
        playerBody.rotation = Quaternion.Euler(targetRotBody);
    }
}

