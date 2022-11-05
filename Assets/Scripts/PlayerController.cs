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

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

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
        
        controller.Move(direction * Time.deltaTime);
    }

    private void DoubleJump()
    {
        direction.y = jumpForce;
        doubleJump = false;
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }
}
