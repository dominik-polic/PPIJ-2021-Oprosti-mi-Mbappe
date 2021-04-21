using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public AudioSource trc;
    public AudioSource skoc;
    public AudioSource skup;

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
        if(ScoreManager.instance.isAlive == false)
        {
            horizontalMove = 0;
            jump = false;
            animator.SetBool("isAlive", false);
            return;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            trc.Stop();
            skoc.Play();
        }

        if (Input.GetAxisRaw("Fire1") > 0.01)   //Now it's sneaking, but all papameter names are left unchanged
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if(horizontalMove != 0)
        {
            if (!trc.isPlaying && !skoc.isPlaying)
            {
                trc.Play();
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
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
