using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    private int JumpCount;
    private float dirX = 0f;
    private enum MovementState { idle, running, jumping, falling };

    [SerializeField] private AudioSource jumpSFX;

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        JumpCount = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && (JumpCount < 2 || isGrounded()))
        {
            jumpSFX.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            JumpCount++;
        }

        if (rb.velocity.y == 0f) { JumpCount = 0; }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        MovementState State;
        if (dirX > 0f)
        {
            State = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            State = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            State = MovementState.idle;
        }


        if(rb.velocity.y > .1f)
        {
            State = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            State = MovementState.falling;
        }


        anim.SetInteger("State", (int)State);
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .0000001f, jumpableGround);
    }
    
}
