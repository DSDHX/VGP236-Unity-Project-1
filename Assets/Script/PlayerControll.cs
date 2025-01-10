using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6.0f;
    [SerializeField]
    private float jumpSpeed = 6.0f;

    private bool isJumping = false;
    private Rigidbody2D PlayerRB = null;
    private Vector3 desiredSpeed = Vector2.zero;

    private void Awake()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRB.linearVelocityX = 0.0f;
        if (Input.GetKey(KeyCode.D))
        {
            PlayerRB.linearVelocityX = moveSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRB.linearVelocityX = -moveSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            PlayerRB.linearVelocityY = jumpSpeed;
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y < transform.position.y)
        {
            isJumping = false;
        }
    }   
}