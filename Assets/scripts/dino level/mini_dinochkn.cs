using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class mini_dinochkn : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float jumpForce = 8f;
    public float gravity = 9.81f * 2f;

    private Animator animator;
    [SerializeField] private AudioSource jumpsoundeffect;
    [SerializeField] private AudioSource diesoundeffect;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0.9f;
    }

    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
        direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                direction = Vector3.up * jumpForce;
                jumpsoundeffect.Play();
                animator.SetTrigger("jump");

            }
            if (Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * jumpForce;
                jumpsoundeffect.Play();
                animator.SetTrigger("jump");
            }
        }

        character.Move(direction * Time.deltaTime);
        animator.speed += 0.00005f;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            animator.enabled = true;
            animator.SetTrigger("die");
            Invoke("delGO",0.9f) ;
            diesoundeffect.Play();
            this.enabled = false;
        }
    }
    private void delGO()
    {
        FindObjectOfType<GameManager_dino>().GameOver();
    }
}