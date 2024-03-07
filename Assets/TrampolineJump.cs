using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineJump : MonoBehaviour
{

    private Animator anim;
    private AudioSource bounceSFX;

    [SerializeField] private float moveSpeed = 7f;
    private float dirX = 0f;
    [SerializeField] private float trampolineJumpForce = 32f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trampoline"))
        {
            anim = collision.gameObject.GetComponent<Animator>();
            bounceSFX = collision.gameObject.GetComponent<AudioSource>();

            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(moveSpeed * dirX, trampolineJumpForce);

            bounceSFX.Play();
            anim.SetTrigger("isStepped");
        }

    }
}
