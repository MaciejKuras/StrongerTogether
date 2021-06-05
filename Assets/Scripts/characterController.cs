using UnityEngine;

public class characterController : MonoBehaviour
{
    float speed = 1f, checkRadius = 0.2f, jumpForce = 20f;
    public bool isGrounded;
    public Transform feetPos;
    public LayerMask whatIsGround;
    public Animator animator;
    public AudioSource audio;
    Rigidbody2D rb;
    public CapsuleCollider2D collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("P1Horizontal");

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
        if (isGrounded && Input.GetButtonDown("P1Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
            audio.Play();
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

        if (isGrounded && Input.GetButton("P1Crouch"))
        {
            collider.size = new Vector2(collider.size.x, 0.5f);
            collider.offset = new Vector2(collider.offset.x, -0.55f);
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            collider.size = new Vector2(collider.size.x, 1.4f);
            collider.offset = new Vector2(collider.offset.x, -0.3f);
            animator.SetBool("IsCrouching", false);
        }
        //if(Input.getbu)
        //if (Input.GetAxisRaw("P1Horizontal") == Input.GetAxisRaw("P2Horizontal")/* && Input.GetAxisRaw("P1Horizontal") != 0*/)
        //{
        //    //transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed * 10f;
        //    rb.velocity = new Vector2(moveInput * speed * 10f, rb.velocity.y);
        //    if (moveInput > 0)
        //    {
        //        transform.eulerAngles = new Vector3(0, 0, 0);
        //    }
        //    else if (moveInput < 0)
        //    {
        //        transform.eulerAngles = new Vector3(0, 180, 0);
        //    }

        //    animator.SetFloat("Speed", Mathf.Abs(moveInput));
        //}
        //else
        //{
        //    rb.velocity = new Vector2(0, rb.velocity.y);
        //}

        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        //if (isGrounded && Input.GetButton("P1Jump") && Input.GetButtonDown("P2Jump") || isGrounded && Input.GetButtonDown("P1Jump") && Input.GetButton("P2Jump"))
        //{
        //    rb.velocity = Vector2.up * jumpForce;
        //    animator.SetBool("IsJumping", true);
        //    audio.Play();
        //}

        //if (Physics2D.OverlapCircle(feetPos.position, checkRadius).CompareTag("Floor"))
        //{
        //    gameObject.transform.parent = Physics2D.OverlapCircle(feetPos.position, checkRadius).transform;
        //    //GetComponent<CapsuleCollider2D>().sharedMaterial.friction = 1;
        //}
        //else
        //{
        //    gameObject.transform.parent = null;
        //    //GetComponent<CapsuleCollider2D>().sharedMaterial.friction = 0;
        //}

        //if (rb.velocity.y < 0 && !isGrounded)
        //{
        //    animator.SetBool("IsJumping", false);
        //    animator.SetBool("IsFalling", true);
        //}
        //else/* if (rb.velocity.y >= 0)*/
        //{
        //    animator.SetBool("IsFalling", false);
        //    //animator.SetBool("IsJumping", false);
        //}
    }
}
