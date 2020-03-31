using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngY;
    [SerializeField]
    float eulerAngZ;

    [SerializeField]
    float colEulerAngX;
    [SerializeField]
    float colEulerAngY;
    [SerializeField]
    float colEulerAngZ;

    public float acceleration = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 100);
    }

    private void Update()
    {
        rb.AddForce(transform.forward * acceleration);
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MoveScript>().die();
        }

        rb.velocity = new Vector3(0, 0, 0);
        colEulerAngX = collision.transform.localEulerAngles.x;
        colEulerAngY = collision.transform.localEulerAngles.y;
        colEulerAngZ = collision.transform.localEulerAngles.z;

        transform.eulerAngles = new Vector3(
            transform.rotation.x,
            eulerAngY + (90 - eulerAngY - colEulerAngY) * 2 + 180,
            transform.rotation.z);
        rb.AddForce(transform.forward * 100);
    }
}