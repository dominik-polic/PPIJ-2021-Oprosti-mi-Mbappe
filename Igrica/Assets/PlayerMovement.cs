using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    bool isRunning = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetAxisRaw("Fire1") > 0.01)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        float modifiedSpeed = horizontalMove;

        if (isRunning) modifiedSpeed *= 1.5f;

        controller.Move(modifiedSpeed * Time.fixedDeltaTime, false, jump, isRunning&&(horizontalMove != 0)?true:false);
        jump = false;

    }
}
