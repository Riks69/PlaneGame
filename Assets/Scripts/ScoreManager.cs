using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public int currentLives = 3;
    
    // Need peavad olema PUBLIC ja sa lohistad need Unity's
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    
    void Start()
    {
        // Kui tekstid on määratud, uuenda kohe
        if (scoreText != null)
            scoreText.text = "Skoor: " + currentScore;
        else
            Debug.LogError("ScoreText puudub! Lohist see ScoreManageri külge!");
        
        if (livesText != null)
            livesText.text = "Elud: " + currentLives;
        else
            Debug.LogError("LivesText puudub! Lohist see ScoreManageri külge!");
    }
    
    public void AddScore(int points)
    {
        currentScore += points;
        if (scoreText != null)
            scoreText.text = "Skoor: " + currentScore;
        Debug.Log("Skoor: " + currentScore);
    }
    
    public void LoseLife()
    {
        currentLives--;
        if (livesText != null)
            livesText.text = "Elud: " + currentLives;
        Debug.Log("Elud: " + currentLives);
        
        if (currentLives <= 0)
        {
            Debug.Log("GAME OVER!");
            Time.timeScale = 0;
        }
    }
}