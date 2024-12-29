using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float JumpForce = 15f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    private bool isGround;
    private GameMage GameMage;
    private AudioMage audioMage;
    private Rigidbody2D rb;
    //private Animation animation;
    private Animator animation;
    private void Awake()
    {
        audioMage = FindAnyObjectByType<AudioMage>();
        animation = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameMage = FindAnyObjectByType<GameMage>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMage.IsGameOver() || GameMage.IsGameWin() )return;
        HandeMovement();
        HandleJump();
        UpdateAnimation();
    }
    private void HandeMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        if (moveInput > 0) transform.localScale = new Vector3(3, 3, 1);
        else if(moveInput < 0) transform.localScale = new Vector3(-3,3,1);


    }
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            audioMage.PlayJumpMusic();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForce);
        }
        isGround = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    private void UpdateAnimation()
    {
        bool isRuning = Mathf.Abs(rb.linearVelocity.x)>0.1f;
        bool isJuming = !isGround;
        animation.SetBool("IsRuning", isRuning);
        animation.SetBool("IsJumping", isJuming);
    }
}
