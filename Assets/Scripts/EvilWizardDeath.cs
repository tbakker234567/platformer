using UnityEngine;
public class EvilWizardDeath : MonoBehaviour
{

    public GameObject sunPrefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("magicbullet"))
        {
            Instantiate(sunPrefab, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
            GameObject.Destroy(collision.gameObject);
        }
    }
}