using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] float jumpForce = 40f;
    [SerializeField] float _rotationSmoothSpeed = 1f;

    Vector3 movement;
    float speed = 0;

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

         movement = new Vector3(horizontalInput, 0f, verticalInput);
        rb.velocity = new Vector3(movement.x * Speed, rb.velocity.y, movement.z * Speed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x,(rb.velocity.y + jumpForce), rb.velocity.z);
        }

        


        // Determine the magnitude of movement to set speed for animation
        float targetSpeed = movement.magnitude > 0 ? 1 : 0; // Assuming 1 is max speed for movement, adjust if necessary

        // Current speed from the Animator
        float currentSpeed = animator.GetFloat("Speed");

        // Smoothly interpolate between the current speed and the target speed (either 1 or 0 based on movement)
        speed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * 0.5f);

        // Apply the interpolated speed to the animator
        animator.SetFloat("Speed", speed);



        RotatePlayer();
    }

    void RotatePlayer()
    {
        if (movement.magnitude > 0)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            Quaternion smoothRotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSmoothSpeed * Time.deltaTime);
            transform.rotation = smoothRotation;
        }
    }
}
