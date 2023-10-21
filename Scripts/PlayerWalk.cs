using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    float speed = 0f;
    public float currentSpeed; // Currentspeed for the player
    Vector2 movement;


    void Update()
    {
        HandleMovementInput();// Handles the input
        HandleAnimator();
    }

    void FixedUpdate()
    {
        HandleMovement(); // Handles the player movement
    }

    void HandleMovementInput()
    {
        // Setting the inputs from the axis to the x and y values for the 'movement' vector
        movement.x = Input.GetAxis("Horizontal"); 
        movement.y = Input.GetAxis("Vertical");
    }

    void HandleMovement()
    {
        rb.velocity = new Vector2 (movement.x * currentSpeed, movement.y * currentSpeed); // In short, makes player move
    }

    void HandleAnimator() // Used to handle animations in the animator tab on Unity 
    {
        speed = rb.velocity.magnitude;
        animator.SetFloat("Speed", speed);
    }

}


