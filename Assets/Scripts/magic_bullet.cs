using Unity.VisualScripting;
using UnityEngine;

public class magic_bullet : MonoBehaviour
{

    float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        GameObject.Destroy(gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("evilguy"))
        {
            GameObject.Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            GameObject.Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy1"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
