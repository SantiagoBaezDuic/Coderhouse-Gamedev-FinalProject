using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float forceToJump = 5f;

    [SerializeField] private float speed = 5f;

    private Animator anim;

    private int jumpCounter;

    [SerializeField] private int maxJumpCounter = 2;

    private bool isGrounded;

    [SerializeField] private Transform groundChecker;

    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float checkDistance = 0.2f;

    private Vector3 yAxis = new Vector3(0, 1, 0);

    [SerializeField] private Transform cam;

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, checkDistance, groundMask);

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < maxJumpCounter)
        {
                rb.AddForce(transform.up * forceToJump, ForceMode.Impulse);
                jumpCounter += 1;
                anim.SetBool("Jump", true);
        }

        if (isGrounded)
        {
            jumpCounter = 0;
            anim.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * vertical * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Forw", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Forw", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * (speed / 2) * vertical * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("Back", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Back", false);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(yAxis, horizontal * 260f * Time.deltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        jumpCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
