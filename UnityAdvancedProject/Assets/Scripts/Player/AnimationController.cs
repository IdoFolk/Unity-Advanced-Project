using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] float jumpForce = 40f;
 

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        rb.velocity = new Vector3(movement.x * Speed, rb.velocity.y, movement.z * Speed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x,(rb.velocity.y + jumpForce), rb.velocity.z);
        }
    }
}
