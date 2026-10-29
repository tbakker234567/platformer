using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    float speed = 8f;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        GameObject.Destroy(gameObject, 1f);
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
