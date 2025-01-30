using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed = 5f;
    public string horizontalInputName; // Different for each player

    [Header("Jump Setting")]
    public float jumpForce = 9f;
    public LayerMask groundLayer;
    public string jumpButton;

    private Rigidbody2D rb;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleIsJump();
        Debug.Log("Are you there? " + isGround);
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
        isGround = Physics2D.OverlapCircle(transform.position + Vector3.down * 0.5f, 0.2f, groundLayer);
        if (isGround && Input.GetButtonDown(jumpButton))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down * 1.2f, 0.2f);
    }
}