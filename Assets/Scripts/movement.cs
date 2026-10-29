using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public magic_bullet MagicBulletPrefab;
    public Transform firePoint;

    [SerializeField] Sprite[] Player_sprites;
    Sprite newSprite;

    public float moveSpeed = 5f, jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);

    private Rigidbody2D rb;
    private bool isGrounded, jumpPressed, jumpHeld, hasWand = false;

    private SpriteRenderer player_spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player_spriteRenderer = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        isGrounded = IsGrounded();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpPressed = true;
            jumpHeld = true;
        }
        if (Input.GetButtonUp("Jump"))
        {
            jumpHeld = false;
        }

        if (move > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (move < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (hasWand == true)
{
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(MagicBulletPrefab, firePoint.position, firePoint.rotation);
        }
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpPressed = false;
        }
        if (!jumpHeld && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0f, Vector2.down, 0.1f, groundLayer);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("wand"))
        {
        newSprite = Player_sprites[1];
        GetComponent<SpriteRenderer>().sprite = newSprite;
        hasWand = true;
        }
    }
}
