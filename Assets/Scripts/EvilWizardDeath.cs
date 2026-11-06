using UnityEngine;
using System.Collections;
public class EvilWizardDeath : MonoBehaviour
{
    public EvilWizard evilWizardScript;
    public GameObject sunPrefab;
    public float speed = 2f;
    private int currentPointIndex = 0;
    public Transform[] targets;

    int damage = 0;
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
            evilWizardScript.evilWizard.flipX = true;
        }
        else if (transform.position.x < targetPoint.position.x)
        {
            evilWizardScript.evilWizard.flipX = false;
        }

        if (damage >= 3)
        {

            Instantiate(sunPrefab, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("magicbullet"))
        {
            damage++;
            GameObject.Destroy(collision.gameObject);
            StartCoroutine(FlashRoutine());
        }
    }
    
    private IEnumerator FlashRoutine()
    {
        evilWizardScript.evilWizard.color = new Color(1f, 0f, 0f, 1f);

        yield return new WaitForSeconds(0.1f);

        evilWizardScript.evilWizard.color = new Color(1f, 1f, 1f, 1f);
    }
}