using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public Rigidbody rb;

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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 100);
    }

    private void Update()
    {
        rb.AddForce(transform.forward * 1);

        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(0, 0, 0);
        colEulerAngX = collision.transform.localEulerAngles.x;
        colEulerAngY = collision.transform.localEulerAngles.y;
        colEulerAngZ = collision.transform.localEulerAngles.z;

        print(transform.name);
        print(colEulerAngY);
        print(eulerAngY);
        transform.eulerAngles = new Vector3(
            transform.rotation.x,
            eulerAngY + (90 - eulerAngY - colEulerAngY) * 2 + 180,
            transform.rotation.z);
        rb.AddForce(transform.forward * 100);
    }
}
