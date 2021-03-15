using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float initialVelocity;
    public float jumpForce;
    public float torqueZ;
    public Vector2 torqueRange;
    public GameObject particleEffect;

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
            rb.AddTorque(new Vector3(Random.Range(torqueRange.x, torqueRange.y), Random.Range(torqueRange.x, torqueRange.y), torqueZ));
        }
        rb.velocity = new Vector3(velocity, rb.velocity.y, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        particleEffect.transform.position = transform.position;
        particleEffect.transform.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
