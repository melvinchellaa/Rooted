using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private float Move;

    public Rigidbody2D rb;

    public bool isJumping;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");

        if (Move != 0) {
            animator.SetFloat("XInput", Move);
        }

        if (Mathf.Abs(Move) > 0.2f) {
            animator.SetBool("isWalking", true);
        } else {
            animator.SetBool("isWalking", false);
        }

        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (rb.velocity.y > 0.1f)
        {
            isJumping = true;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}
