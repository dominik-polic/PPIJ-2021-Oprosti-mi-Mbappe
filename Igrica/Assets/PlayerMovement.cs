using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public AudioSource trc;
    public AudioSource skoc;
    public AudioSource skup;

    bool useTouchUI = true;

    public float runSpeed = 40f;

    string TOUCH_ENABLED = "TOUCH_ENABLED";
    int DISABLED = 0;

    float horizontalMove = 0f;

    bool jump = false;

    bool isRunning = false;

    bool invertRunning = false;

    public Canvas touchUICanvas;

    void Start()
    {
        if (PlayerPrefs.GetInt(TOUCH_ENABLED) == DISABLED)
        {
            useTouchUI = false;
            touchUICanvas.enabled = false;
        }
        else
        {
            CrossPlatformInputManager.SetAxisZero("Fire1");
            CrossPlatformInputManager.SetAxisZero("Horizontal");
            CrossPlatformInputManager.SetButtonUp("Jump");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreManager.instance.isAlive == false)
        {
            horizontalMove = 0;
            jump = false;            
            return;
        }
        if (useTouchUI)
        {
            horizontalMove = ((Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal")) > 0.01) ? 1 : 0) * runSpeed * (CrossPlatformInputManager.GetAxis("Horizontal") < 0 ? -1 : 1);
        }
        else
        {
            horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        bool tempif;
        if (useTouchUI)
        {
            tempif = (CrossPlatformInputManager.GetButtonDown("Jump"));
        }
        else
        {
            tempif = (Input.GetButtonDown("Jump"));
        }

        if(tempif)
        {
            jump = true;
            animator.SetBool("isJumping", true);
            trc.Stop();
            skoc.Play();
        }

        bool tempif2;
        if (useTouchUI) {
            tempif2 = (CrossPlatformInputManager.GetAxis("Fire1") > 0.01);   //Now it's sneaking, but all papameter names are left unchanged
        }
        else
        {
            tempif2 = (Input.GetAxis("Fire1") > 0.01);   //Now it's sneaking, but all papameter names are left unchanged
        }

        if(tempif2)
        {
                isRunning = !invertRunning;
                animator.SetBool("isSlow", invertRunning);
        }
        else
        {
            isRunning = invertRunning;
            animator.SetBool("isSlow", !invertRunning);
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

        controller.Move(modifiedSpeed * Time.fixedDeltaTime, false, jump, isRunning); //&&(horizontalMove != 0)?true:false);
        jump = false;

    }
}
