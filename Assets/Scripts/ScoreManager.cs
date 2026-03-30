using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public int currentLives = 3;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    
    void Start()
    {
        UpdateUI();
    }
    
    public void AddScore(int points)
    {
        currentScore += points;
        UpdateUI();
        Debug.Log("Skoor: " + currentScore);
    }
    
    public void LoseLife()
    {
        currentLives--;
        UpdateUI();
        Debug.Log("Elud: " + currentLives);
        
        if (currentLives <= 0)
        {
            Debug.Log("GAME OVER!");
            Time.timeScale = 0;
        }
    }
    
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Skoor: " + currentScore;
        
        if (livesText != null)
            livesText.text = "Elud: " + currentLives;
    }
}