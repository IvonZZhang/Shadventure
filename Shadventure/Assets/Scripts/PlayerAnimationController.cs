using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float blinkCounter = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Random.InitState(0);
    }

    void Start()
    {
        
    }

 
    void Update()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetFloat("VelocityX", Mathf.Abs(move.x));

    }

    void FixedUpdate()
    {
        blinkCounter += Random.value;
        if(blinkCounter > 60)
        {
            animator.SetTrigger("BlinkTrigger");
            blinkCounter = 0;
        }

    }
}
