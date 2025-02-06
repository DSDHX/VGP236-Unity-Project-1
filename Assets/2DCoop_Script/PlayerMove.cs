using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public string horizontalInputName; // Different for each player

    [Header("Jump Setting")]
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public string jumpButton;

    private Rigidbody2D rb;
    private bool isGround;
    private Animator anim;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleIsJump();

        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("IsGround", isGround);

        // temp
        if (!isGround && !isJumping)
        {
            isJumping = true;
        }
        if (isGround && isJumping)
        {
            isJumping = false;
        }
    }
    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw(horizontalInputName);
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput != 0)
        {
            Vector2 playerScale = transform.localScale;
            playerScale.x = Mathf.Abs(playerScale.x) * (moveInput > 0 ? 1 : -1);
            transform.localScale = playerScale;
        }
    }

    void HandleIsJump()
    {
        isGround = Physics2D.OverlapCircle(transform.position + Vector3.down * 1.1f, 0.2f, groundLayer);
        if (isGround && Input.GetButtonDown(jumpButton))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        float moveInput = Input.GetAxisRaw(horizontalInputName);
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 1.1f, 0.2f);
    }
}