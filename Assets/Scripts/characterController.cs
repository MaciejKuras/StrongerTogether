using UnityEngine;

public class characterController : MonoBehaviour
{
    float speed = 1f, checkRadius = 0.3f, jumpForce = 20f;
    bool isGrounded;
    public Transform feetPos;
    public LayerMask whatIsGround;
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("P1Horizontal");
        if (Input.GetAxisRaw("P1Horizontal") == Input.GetAxisRaw("P2Horizontal") && Input.GetAxisRaw("P1Horizontal") != 0)
        {
            transform.position += new Vector3(moveInput, 0, 0) * Time.deltaTime * speed * 10f;
        }

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (isGrounded && Input.GetButton("P1Jump") && Input.GetButtonDown("P2Jump") || isGrounded && Input.GetButtonDown("P1Jump") && Input.GetButton("P2Jump"))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
