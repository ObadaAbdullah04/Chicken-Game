using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public float speed = 2.0f;
    public Transform player;
    public float stoppingDistance = 2.0f;
    private Animator animator;
    public int currentHealth;
    public int damage = 1;
    private bool isFacingRight = true;
    //
    [SerializeField] efhealthbar healthbar;
    //
    public float cooldownTime = 5.0f; // Cooldown time in seconds
    private float cooldownTimer = 0.0f;
    private bool isCooldown = false;
    private void Awake()
    {
        healthbar=GetComponentInChildren<efhealthbar>();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(currentHealth,maxHealth);
    }

    private void Update()
    {
        // Calculate moveInput based on the enemy's position and the player's position
        float moveInput = Mathf.Sign(player.position.x - transform.position.x);

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                isCooldown = false;
            }
        }
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("ehit");
        healthbar.UpdateHealthBar(currentHealth,maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void Attack()
    {
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    void StartCooldown()
    {
        isCooldown = true;
        cooldownTimer = cooldownTime;
        //cooldownText.text = cooldownTimer.ToString("F1");
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            TakeDamage(damage);
        }
    }
    */
}
