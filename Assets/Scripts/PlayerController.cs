using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool doubleJump = true;
    public Animator animator;
    public Transform model;

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("grounded", isGrounded);
        animator.SetFloat("speed", Mathf.Abs(hInput));

        if (PlayerManager.gameOver)
        {
            animator.SetTrigger("death");
            this.enabled = false;
        }

        if (isGrounded)
        {
            direction.y = 0;
            doubleJump = true;
            if(Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            if (doubleJump & Input.GetButtonDown("Jump"))
            {
                DoubleJump();
            }
        }

        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
            model.rotation = newRotation;
        }
        
        controller.Move(direction * Time.deltaTime);

        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void DoubleJump()
    {
        animator.SetTrigger("secondjump");
        direction.y = jumpForce;
        doubleJump = false;
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
