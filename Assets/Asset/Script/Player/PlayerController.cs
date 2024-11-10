using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variable")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;

    [Header("Shoot Variable")]
    public GameObject projectilePrefab; 
    public Transform shootPoint; 
    public float shootForce = 10f;

    [Header("Physics Variable")]
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    public Animator playerAnimator;

    public float MoveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        playerAnimator.SetFloat("Speed", rb.velocity.magnitude);

    }

    void Move()
    {
        
        rb.velocity = new Vector2(MoveInput * moveSpeed, rb.velocity.y);

        
        if (MoveInput > 0 && isFacingRight)
        {
            Flip();
            shootPoint.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (MoveInput < 0 && !isFacingRight)
        {
            Flip();
            shootPoint.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

     public void Jump()
    {
        if (!isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;

            playerAnimator.SetBool("Jumping", true);
        }
            
        
    }

    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
        Vector2 shootDirection = isFacingRight ? Vector2.right : Vector2.left;
        rbProjectile.AddForce(shootDirection * shootForce, ForceMode2D.Impulse);
        playerAnimator.SetTrigger("Shoot");
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            playerAnimator.SetBool("Jumping", false);
        }

        if (collision.gameObject.CompareTag("GameOver"))
        {
            GUI_GameOverEvent.OnGameOver?.Invoke();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            ScoreEvent_Handler.ScorePlus?.Invoke();
            Destroy(collision.gameObject);
        }

        
    }
}
