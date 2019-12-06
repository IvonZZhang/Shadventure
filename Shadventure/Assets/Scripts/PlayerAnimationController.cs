using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private CharacterController2D charCont;
    private float blinkCounter = 0;
    private int sitCounter = 0;
    private Rigidbody2D rb2d;
    private bool falling = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        charCont = GetComponent<CharacterController2D>();
        rb2d = GetComponent<Rigidbody2D>();
        Random.InitState(0);
    }

    void Start()
    {
        
    }

 
    void Update()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");


        animator.SetFloat("VelocityX", Mathf.Abs(move.x));
        animator.SetFloat("VelocityY", rb2d.velocity.y);
        if (!falling)
        {
            if(rb2d.velocity.y < -1.0f)
            {
                falling = true;
                animator.SetTrigger("StartFalling");
            }
        }
        else
        {
            if(rb2d.velocity.y > -1.0f)
            {
                falling = false;
            }
        }


    }

    void FixedUpdate()
    {
        blinkCounter += Random.value;
        if(blinkCounter > 60)
        {
            animator.SetTrigger("BlinkTrigger");
            blinkCounter = 0;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Shad_standing") || animator.GetCurrentAnimatorStateInfo(0).IsName("Shad_blinking"))
        {
            sitCounter++;
            if(sitCounter > 120)
            {
                animator.SetTrigger("StartSitting");
            }
        }
        else
        {
            sitCounter = 0;
        }

    }
}
