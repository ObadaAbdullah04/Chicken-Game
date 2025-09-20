using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_swipe : MonoBehaviour
{
    private Rigidbody2D rb;
    private float deltaY, deltaX;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFacingLeft = false;
    private bool isFacingRight = true;
    public float moveSpeed = 5f;

    public int value;
    public int value2;
    public int s = 0;

    [SerializeField] private AudioSource diesoundeffect;
    [SerializeField] private AudioSource eatsoundeffect;
    [SerializeField] private AudioSource hurtsoundeffect;
    [SerializeField] private AudioSource heartsoundeffect;

    private bool isTouching = false; // Track whether a touch is active

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    isTouching = true; // Finger is touching the screen
                    break;

                case TouchPhase.Moved:
                    if (isTouching)
                    {
                        float targetX = touchPos.x - deltaX;
                        rb.MovePosition(new Vector2(targetX, transform.position.y));

                        // Flip the sprite based on movement direction
                        if (targetX < transform.position.x)
                        {
                            // Moving left, flip the sprite
                            spriteRenderer.flipX = true;
                        }
                        else if (targetX > transform.position.x)
                        {
                            // Moving right, reset the sprite's flip
                            spriteRenderer.flipX = false;
                        }
                        animator.SetBool("IsRunning", true); 
                    }
                    break;

                case TouchPhase.Ended:
                    isTouching = false; // Finger is released
                    rb.velocity = Vector2.zero;
                    animator.SetBool("IsRunning", false);
                    break;
            }
        }
        /*
        // Handle player movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Flip the player sprite based on the movement direction
        if ((isFacingRight && moveInput < 0))
        {
            Flip();
            isFacingLeft = true;
        }
        if ((!isFacingRight && moveInput > 0))
        {
            Flip();
            isFacingLeft = false;
        }
        //animator
        if (moveInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        */
        
    }
    private void Flip()
    {
        // Flip the player sprite horizontally
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fruit"))
        {
            handmadecounter.instance.Increasecoins(value);
            Destroy(collision.gameObject);
            eatsoundeffect.Play();
        }
        if (collision.gameObject.CompareTag("badfruit"))
        {
            if (s <= 1)
            {
                animator.SetTrigger("hurt");
            }
            handmadecounter.instance.Icecreamscore(value2);
            Destroy(collision.gameObject);
            hurtsoundeffect.Play();
            s++;
        }
        if (s == 3)
        {
            animator.SetBool("IsRunning", false);
            animator.SetTrigger("die");
            diesoundeffect.Play();
            hurtsoundeffect.Pause();
            eatsoundeffect.Pause();
            this.enabled = false;
        }
        if (collision.gameObject.CompareTag("Heart"))
        {
            value2 = -1;
            if (handmadecounter.instance.icecreamscore <= 2)
            {
                handmadecounter.instance.Icecreamscore(value2);
                heartsoundeffect.Play();
                s -= 1;
            }
            Destroy(collision.gameObject);
        }
        value2 = 1;
    }
   


}
