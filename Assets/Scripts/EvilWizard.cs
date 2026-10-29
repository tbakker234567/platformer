using UnityEngine;
using UnityEngine.SceneManagement;

public class EvilWizard : MonoBehaviour
{

    public GameObject fireballPrefab;
    public Transform firePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time % 1.5f < Time.deltaTime)
        
        {
                Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Deathscreen");
        }
    }
}
