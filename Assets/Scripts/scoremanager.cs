using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoremanager : MonoBehaviour
{

    public static scoremanager instance;
    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        instance = this;
        if (scoreText == null)
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        if (scoreText == null)
        {
            scoreText = FindObjectOfType<TextMeshProUGUI>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "Coins: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addpoint()
    {
        score += 1;
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score.ToString();
        }
    }
}