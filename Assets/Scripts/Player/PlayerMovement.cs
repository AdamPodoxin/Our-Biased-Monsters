using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1f;

    public bool canMove = true;

    private Rigidbody2D rb;
    private PlayerAnimator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<PlayerAnimator>();
    }

    private void Update()
    {
        Move(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
    }

    private void Move(Vector2 movement)
    {
        if (canMove)
        {
            rb.velocity = movement * moveSpeed;
            animator.AnimatePlayer(movement);
        }
        else
        {
            rb.velocity = Vector2.zero;
            animator.AnimatePlayer(Vector2.zero);
        }
    }
}
