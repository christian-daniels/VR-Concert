using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f; // we project a sphere on the ground to check if there are any collisions - if so we are grounded
    Vector3 velocity;
    bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f; // small number that will force our player on the ground
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Create a direction we want to move 
        Vector3 move = transform.right * x + transform.forward * z;
        // Pass move with a speed that is framerate independent to controller
        controller.Move(move * speed * Time.deltaTime);

        // jumping
        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
