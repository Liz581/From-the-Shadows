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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forward = Input.GetKey("w");
        bool backward = Input.GetKey("s");
        bool isWalking = animator.GetBool("isWalking");
        bool backwardsWalk = animator.GetBool("backWalk");
        bool jump = animator.GetBool("jump");
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (forward) {
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
            if (!isWalking)
                animator.SetBool("isWalking", true);
        }
        else if (!forward && isWalking)
            animator.SetBool("isWalking", false);
        
        if (backward) {
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;
            if (!backwardsWalk)
                animator.SetBool("backWalk", true);
        }
        else if (!backward && backwardsWalk)
            animator.SetBool("backWalk", false);

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
        if (!isGrounded && jump) {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);
            animator.SetBool("jump", false);
        }

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(t.up * force, ForceMode.Impulse);
            if (!jump)
                animator.SetBool("jump", true);
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
