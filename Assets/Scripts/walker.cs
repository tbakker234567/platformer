using UnityEngine;
using UnityEngine.SceneManagement;

public class walker : MonoBehaviour
{
        public Transform[] targets;
        private SpriteRenderer blobmeister;

    private int currentPointIndex = 0;

    public float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blobmeister = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
       void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (targets.Length == 0) return;
        Transform targetPoint = targets[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= targets.Length)
            {
                currentPointIndex = 0;
            }
        }
        else if (transform.position.x > targetPoint.position.x)
        {
            blobmeister.flipX = false;
        }
        else if (transform.position.x < targetPoint.position.x)
        {
            blobmeister.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Deathscreen");
        }

        if (collision.gameObject.CompareTag("magicbullet"))
        {
            GameObject.Destroy(gameObject);
            GameObject.Destroy(collision.gameObject);
        }
    }
}
