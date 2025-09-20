using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class Fluppytest : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotationspeed = 10f;
    private Rigidbody2D rb;
    private Animator animator;

    private bool hasPlayedSound = false;

    [SerializeField] private AudioSource diesoundeffect;
    [SerializeField] private AudioSource swingsoundeffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.velocity = Vector2.up * velocity;
            swingsoundeffect.Play();
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
            swingsoundeffect.Play();
        }

    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y * rotationspeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasPlayedSound)
        {
            animator.SetTrigger("die");
            diesoundeffect.Play();
            hasPlayedSound = true;
            Invoke("GameOverWithDelay", 1.3f);
        }

        this.enabled = false;
    }
    private void GameOverWithDelay()
    {
        GameManager.instance.GameOver();
    }
    
}
