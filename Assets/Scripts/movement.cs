using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public magic_bullet MagicBulletPrefab;
    public Transform firePoint;

    [SerializeField] Sprite[] Player_sprites;
    Sprite newSprite;

    public float moveSpeed = 5f, jumpForce = 10f, fireTimer = 0;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.1f);

    private Rigidbody2D rb;
    private bool isGrounded, jumpPressed, jumpHeld;
    public bool hasWand = false;

    private SpriteRenderer player_spriteRenderer;

    public Image signText1, signText2;

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
            if (Input.GetButtonDown("Fire1") && fireTimer >= 1f)
            {
                Instantiate(MagicBulletPrefab, firePoint.position, firePoint.rotation);
                fireTimer = 0f;
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

        fireTimer += Time.fixedDeltaTime;
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(groundCheck.position, groundCheckSize, 0f, Vector2.down, 0.1f, groundLayer);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("wand"))
        {
            newSprite = Player_sprites[1];
            GetComponent<SpriteRenderer>().sprite = newSprite;
            hasWand = true;
        }

        if (collision.gameObject.CompareTag("ship_entrance") && hasWand && true)
        {
            SceneManager.LoadScene("level-2");
        }

        if (collision.gameObject.CompareTag("sign-1"))
        {
            signText1.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("sign-2"))
        {
            signText2.gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("cloud"))
        {
            SceneManager.LoadScene("level-1");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("sign-1"))
        {
            signText1.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("sign-2"))
        {
            signText2.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            SceneManager.LoadScene("level-1-death");
        }
    }
}
