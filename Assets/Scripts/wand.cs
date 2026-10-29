using Unity.VisualScripting;
using UnityEngine;

public class wand : MonoBehaviour
{

    [SerializeField] Sprite[] Wand_sprites;
    Sprite newSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            newSprite = Wand_sprites[0];
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
}
}