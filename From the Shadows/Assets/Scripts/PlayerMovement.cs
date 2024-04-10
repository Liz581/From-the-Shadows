using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15.0f;
    public float rotationSpeed = 90;
    public float force = 20f;
    public float stepHeight = 0.5f; // Adjust this value according to your needs
    public float stepDistance = 0.5f; // Adjust this value according to your needs
    Rigidbody rb;
    Transform t;

    public Animator animator;

    public Transform groundCheck;
    public LayerMask groundMask;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", 0);
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
            animator.SetFloat("Speed", 1);
        } else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
            animator.SetFloat("Speed", 1);
        }
            

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(t.up * force, ForceMode.Impulse);
        }

        // Step over small obstacles
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, stepDistance))
        {
            if (!isGrounded && hit.distance < stepDistance && hit.distance > 0.1f)
            {
                transform.position += Vector3.up * stepHeight;
            }
        }
    }
}
