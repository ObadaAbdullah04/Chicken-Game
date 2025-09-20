using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class chkn_mini1 : MonoBehaviour
{
    // Player movement variables
    //public float moveSpeed = 0f;
    public float jumpForce = 10f;
    // Player animation variables
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Ground check variables
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector3 startingPosition;
    // Rigidbody2D variable
    private Rigidbody2D rb;
    //ground
    bool OnGround;
    private GameManager gameManager;

    //private Rigidbody2D playerRigidbody;
    private bool isFacingRight = true;
    public float jumpDampening = 0.5f;
    public float horizontalJumpForce = 0.05f;


    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator and SpriteRenderer components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        //ground
        OnGround = true;
        //
        gameManager = FindObjectOfType<GameManager>();
        //
    }
    bool isGrounded
    {
        get { return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); }
    }
    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isGrounded && OnGround)
        {
            JumpLeft();
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began && touch.position.x > Screen.width / 2 && isGrounded && OnGround)
            {
                JumpRight();
                moveInput = 1f;
                
            }
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began && touch.position.x < Screen.width / 2 && isGrounded && OnGround)
            {
                JumpLeft();
                moveInput = -1f;

            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && isGrounded && OnGround)
        {
            JumpRight();
        }
        if ((isFacingRight && moveInput < 0))
        {
            Flip();
            
        }
        if ((!isFacingRight && moveInput > 0))
        {
            Flip();
            
        }
    }
    void JumpLeft()
    {

        
        rb.velocity = new Vector2(-horizontalJumpForce, jumpForce * jumpDampening);
        animator.SetTrigger("jump");
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
    }

    void JumpRight()
    {

        
        rb.velocity = new Vector2(horizontalJumpForce, jumpForce * jumpDampening);
        animator.SetTrigger("jump");
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
        

    }
    private void Flip()
    {
        // Flip the player sprite horizontally
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            animator.SetTrigger("die");
        }
        
    }
    
         

}
