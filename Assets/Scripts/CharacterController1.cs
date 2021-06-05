using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    float speed = 1f, checkRadius = 0.2f, jumpForce = 20f;
    public bool isGrounded;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public Animator animator;
    public AudioSource audio;
    Rigidbody2D rb;

    public Collider2D crouchDisableCollider;
    public Transform ceilingCheck;
    const float ceilingRadius = 0.2f;
    private bool isCrouching = false;
    private bool isUnderCeiling;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        crouchDisableCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("P1Horizontal");

        //transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed * 10f;
        rb.velocity = new Vector2(moveInput * speed * 10f, rb.velocity.y);
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        animator.SetFloat("Speed", Mathf.Abs(moveInput));



        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded && Input.GetButton("P1Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
            audio.Play();
        }


        isUnderCeiling = Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround);

        if (isGrounded && Input.GetButton("P1Crouch"))
        {
            animator.SetBool("IsCrouching", true);
            crouchDisableCollider.enabled = false;

            isCrouching = true;

        }
        else
        {
            isCrouching = false;
        }

        if (isCrouching && isUnderCeiling)
        {
            animator.SetBool("IsCrouching", true);
            crouchDisableCollider.enabled = false;

            isCrouching = true;
        }

        else if (!isCrouching && !isUnderCeiling)
        {
            animator.SetBool("IsCrouching", false);
            crouchDisableCollider.enabled = true;

            isCrouching = false;
        }


        if (Physics2D.OverlapCircle(feetPos.position, checkRadius).CompareTag("Floor"))
        {
            gameObject.transform.parent = Physics2D.OverlapCircle(feetPos.position, checkRadius).transform;
            //GetComponent<CapsuleCollider2D>().sharedMaterial.friction = 1;
        }
        else
        {
            gameObject.transform.parent = null;
            //GetComponent<CapsuleCollider2D>().sharedMaterial.friction = 0;
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        else/* if (rb.velocity.y >= 0)*/
        {
            animator.SetBool("IsFalling", false);
            //animator.SetBool("IsJumping", false);
        }
    }
}
