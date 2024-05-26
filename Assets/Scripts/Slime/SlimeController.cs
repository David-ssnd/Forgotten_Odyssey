using System.Collections;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 5f;
    public float changeDirectionTime = 2f;
    public float jumpIntervalMin = 2f;
    public float jumpIntervalMax = 5f;
    public Transform playerTransform; // Reference to the player's transform

    private Rigidbody2D rb;
    private float timer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        timer = changeDirectionTime;

        // Set initial direction (left or right)
        moveSpeed = Random.Range(0, 2) == 0 ? -moveSpeed : moveSpeed;

        // Start the jump coroutine
        StartCoroutine(RandomJump());
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (isGrounded)
        {
            if (timer <= 0f)
            {
                ChangeDirection(); // Remove this line to stop random direction changes
                timer = changeDirectionTime;
            }
        }

        // Adjust moveSpeed to follow the player
        if (playerTransform != null)
        {
            float direction = Mathf.Sign(playerTransform.position.x - transform.position.x);
            moveSpeed = direction * Mathf.Abs(moveSpeed);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Move horizontally
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void ChangeDirection()
    {
        if (isGrounded)
        {
            // Change movement direction
            moveSpeed = -moveSpeed;

            // Flip the sprite to match the movement direction
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    IEnumerator RandomJump()
    {
        while (true)
        {
            float interval = Random.Range(jumpIntervalMin, jumpIntervalMax);
            yield return new WaitForSeconds(interval);

            if (isGrounded)
            {
                // Jump when grounded
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
{
    // Check if the slime is grounded
    foreach (ContactPoint2D contactPoint in collision.contacts)
    {
        if (contactPoint.normal.y > 0.1f) // Adjust the threshold as needed
        {
            isGrounded = true;
            break;
        }
    }

    if (collision.collider.CompareTag("Player"))
    {
        GameData.health -= 1;
    }
}

    void OnCollisionExit2D(Collision2D collision)
    {
        // Update grounded status when leaving the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }
}
