using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float initialVelocity;
    public float jumpForce;
    private float velocity;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        velocity = initialVelocity;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(new Vector3(0, jumpForce, 0));
            rb.AddTorque(new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20)));
        }
        rb.velocity = new Vector3(velocity, rb.velocity.y, rb.velocity.z);
    }
}
