using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    private ScoreManager scoreManager;
    
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager EI LEITUD! Lisa GameManager objekt stseeni!");
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            Debug.Log("Skooritsoon!");
            if (scoreManager != null)
                scoreManager.AddScore(10);
            Destroy(other.gameObject);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Kokkupõrge!");
            if (scoreManager != null)
                scoreManager.LoseLife();
            Destroy(collision.gameObject);
            
            // Taasta lennuk algusesse
            transform.position = new Vector3(0, 2, 0);
        }
    }
}