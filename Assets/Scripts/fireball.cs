using UnityEngine;
using UnityEngine.SceneManagement;

public class fireball : MonoBehaviour
{
    float speed = 4f;
    private Transform playerTransform;


    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            playerTransform = player.transform;
        }

        Destroy(gameObject, 2f);
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("level-2-death");
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            GameObject.Destroy(gameObject);
        }
         if (collision.gameObject.CompareTag("magicbullet"))
        {
            GameObject.Destroy(collision.gameObject);
            GameObject.Destroy(gameObject);
        }
    }
}