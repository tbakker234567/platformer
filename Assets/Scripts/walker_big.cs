using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class walker_big : MonoBehaviour
{
    [SerializeField] private Color flashColor = Color.red;
    [SerializeField] private float flashDuration = 0.15f;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine flashCoroutine;

    int damage;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

     public void TriggerFlash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        spriteRenderer.color = originalColor;
        flashCoroutine = null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("magicbullet"))
        {
            damage += 1;
            GameObject.Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("level-1-death");
        }

        if (collision.gameObject.CompareTag("magicbullet") && damage == 10)
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(collision.gameObject);
        }
    }
}
