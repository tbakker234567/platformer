using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{

    public GameObject bullet;

    public bullet BlobBulletPrefab;
    public Transform firePoint;



    void Start()
    {
    }

    void Update()
    {
        if (Time.time % 2f < Time.deltaTime)

        {
            Instantiate(BlobBulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Deathscreen");
        }
    }

}