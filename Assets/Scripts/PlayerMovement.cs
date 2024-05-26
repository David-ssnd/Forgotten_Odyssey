using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private float dirX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private CameraController cameraController;
    private enum MovementState { idle, running, jumping, falling }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f) {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirX < 0f) {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f) {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f) {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CamFreeze") && collision != null)
        {
            cameraController.startAnim = false;
            cameraController.canMove = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("CamFreeze"))
        {
            if (cameraController != null)
            {
                cameraController.startAnim = false;
                cameraController.canMove = true;
            }
            else
            {
                Debug.LogError("cameraController is null");
            }
        }
    }
}