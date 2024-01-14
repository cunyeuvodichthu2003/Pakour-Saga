using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D rb;
    private bool runBegun;
    [Header("Collision Info")]
    public float groundCheckDistance = 0f;
    public LayerMask whatIsGround;
    private bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
        CheckInput();
        if (runBegun)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void CheckCollision()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire2"))
            runBegun = true;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x,transform.position.y - groundCheckDistance));
    }
}
