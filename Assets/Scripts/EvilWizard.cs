using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilWizard : MonoBehaviour
{

    public GameObject fireballPrefab;
    public Transform firePoint;
    public SpriteRenderer evilWizard;


    void Start()
    {
        evilWizard = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time % 2f < Time.deltaTime)

        {
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("level-2-death");
        }
    }
}
