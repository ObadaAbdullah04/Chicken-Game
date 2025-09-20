using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Player movement variables
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // Player health variables
    public int maxHealth = 3;
    private int currentHealth;

    // Player animation variables
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Ground check variables
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector3 startingPosition;
    public int damage = 1;

    // Rigidbody2D variable
    private Rigidbody2D rb;
    //ground
    bool OnGround;

    //things
    public GameObject attackPoint;
    public float radius ;
    public LayerMask Enemies;

    // Dash variables
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 2f;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    private Vector3 dashStartPosition;
    private Vector3 dashTargetPosition;
    //
    private GameManager gameManager;
    //
    public float Health, MaxHealth;
    [SerializeField]
    
    private HealthBarUI healtBar;
    //
    private bool isFacingRight = true;
    /*
    public Transform bulletspawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    //bullet extras
    public int maxbullet = 5;
    */
    private bool isFacingLeft = false;
    //
    public float cooldownTime = 5.0f; // Cooldown time in seconds
    private float cooldownTimer = 0.0f;
    private bool isCooldown = false;
    //public Text cooldownText;
    //for enemy attack cooldown
    public float cooldownTime2 = 5.0f; // Cooldown time in seconds
    private float cooldownTimer2 = 0.0f;
    private bool isCooldown2 = false;
    //public Text cooldownText2;
    public float cooldownTime3 = 5.0f; // Cooldown time in seconds
    private float cooldownTimer3 = 0.0f;
    private bool isCooldown3 = false;
    //public Text cooldownText3;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        // Set the player's initial health
        currentHealth = maxHealth;
        startingPosition = transform.position;
        //ground
        OnGround=true;
        //
        gameManager = FindObjectOfType<GameManager>();
        //
        healtBar.SetMaxHealth(MaxHealth);
    }
    bool isGrounded
    {
        get { return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); }
    }
    private void Update()
    {
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
        if (moveInput != 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetMouseButtonDown(0) && !isCooldown)
        {
            animator.SetTrigger("IsAttacking");
            StartCooldown();
            //Invoke("StartCooldown", 0.5f);
        }

        animator.SetBool("IsRunning", Mathf.Abs(moveInput) > 0);

        if (Input.GetButtonDown("Jump") && isGrounded && OnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
        // Handle player dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f)
        {
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }

        UpdateCooldownTimer();
        /*
        if (Input.GetKeyDown(KeyCode.F) && !isCooldown3)
        {
            var bullet = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Adjust bullet direction based on player's facing direction
            Vector3 bulletDirection = isFacingLeft ? -bulletspawn.right : bulletspawn.right;

            // Set bullet's velocity
            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;
            //my bullet counter
            maxbullet -=1;
            if (maxbullet <= -1)
            {
                bullet.SetActive(false);
                maxbullet = 0;
            }
            else
                bullet.SetActive(true);
            StartCooldown3();
        }
        */
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            //cooldownText.text = cooldownTimer.ToString("F1"); // Display remaining time

            if (cooldownTimer <= 0)
            {
                isCooldown = false;
                //cooldownText.text = "Ready";
            }
        }
        if (isCooldown2)
        {
            cooldownTimer2 -= Time.deltaTime;
            //cooldownText.text = cooldownTimer.ToString("F1"); // Display remaining time

            if (cooldownTimer2 <= 0)
            {
                isCooldown2 = false;
                //cooldownText.text = "Ready";
            }
        }
        if (isCooldown3)
        {
            cooldownTimer3 -= Time.deltaTime;
            //cooldownText.text = cooldownTimer.ToString("F1"); // Display remaining time

            if (cooldownTimer3 <= 0)
            {
                isCooldown3 = false;
                //cooldownText.text = "Ready";
            }
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SetHealth(-1f);
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            animator.SetTrigger("die");
            Invoke("Die", 1.15f);
        }
    }

    private void Die()
    {
        transform.position = startingPosition;
        // Reset the player's health
        currentHealth = maxHealth;
        gameManager.RestartGame();
        animator.enabled = false;
    }
    public void attack ()
    {
        Collider2D[]Enemy= Physics2D.OverlapCircleAll(attackPoint.transform.position,radius,Enemies);
        foreach (Collider2D EnemyGameObject in Enemy)
        {
            Debug.Log("hit enemy");
            EnemyGameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position,radius);
    }
     private void StartDash()
    {
        isDashing = true;
        dashStartPosition = transform.position;
        dashTargetPosition = dashStartPosition + (Vector3.right * dashDistance);
        dashTimer = 0f;
        //animator.SetBool("IsDashing", true);
    }

    private void Dash()
    {
     if (dashTimer < dashDuration)
     {
        float t = dashTimer / dashDuration;
        transform.position = Vector3.Lerp(dashStartPosition, dashTargetPosition, t);
        dashTimer += Time.deltaTime;
     }
     else
     {
        // Reset dash variables
        isDashing = false;
        dashCooldownTimer = dashCooldown;
        //animator.SetBool("IsDashing", false);
     }
    }
    private void UpdateCooldownTimer()
    {
     if (dashCooldownTimer > 0f)
     {
        dashCooldownTimer -= Time.deltaTime;
        if (dashCooldownTimer < 0f)
        {
            dashCooldownTimer = 0f;
        }
     }
    }
    public void SetHealth(float healthChange)
    {
        Health += healthChange;
        Health = Mathf.Clamp(Health,0,MaxHealth);

        healtBar.SetHealth(Health);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Heart"))
        {
            Destroy(other.gameObject);
            if (currentHealth < maxHealth)
            { 
                SetHealth(+1f);
               currentHealth += 1;
            }
        }
        if (other.gameObject.CompareTag("Enemy") && !isCooldown2)
        {
            TakeDamage(damage);
            StartCooldown2();
        }
        /*
        if (other.gameObject.CompareTag("bullet"))
        {
            maxbullet += 1;
            Destroy(other.gameObject);
        }
        */
    }
    void StartCooldown()
    {
        isCooldown = true;
        cooldownTimer = cooldownTime;
        //cooldownText.text = cooldownTimer.ToString("F1");
    }
    void StartCooldown2()
    {
        isCooldown2 = true;
        cooldownTimer2 = cooldownTime2;
        //cooldownText.text = cooldownTimer.ToString("F1");
    } 
    void StartCooldown3()
    {
        isCooldown3 = true;
        cooldownTimer3 = cooldownTime3;
        //cooldownText.text = cooldownTimer.ToString("F1");
    }

}