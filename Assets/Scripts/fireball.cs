using UnityEngine;
using UnityEngine.SceneManagement;

public class fireball : MonoBehaviour
{
    float speed = 8f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        GameObject.Destroy(gameObject, 3.3f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Deathscreen");
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
