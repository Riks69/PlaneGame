using UnityEngine;

public class CrashDetector : MonoBehaviour
{
    [Header("Heli")]
    public AudioClip crashSound;
    public AudioClip scoreSound;
    
    [Header("Efektid")]
    public GameObject crashEffect;
    public GameObject scoreEffect;
    
    private ScoreManager scoreManager;
    private AudioSource audioSource;
    private Vector3 startPosition;
    private Quaternion startRotation;
    
    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Efektid
            if (crashEffect != null)
                Instantiate(crashEffect, transform.position, Quaternion.identity);
            
            if (crashSound != null)
                audioSource.PlayOneShot(crashSound);
            
            // Võta elu
            if (scoreManager != null)
                scoreManager.LoseLife();
            
            // Hävita takistus
            Destroy(collision.gameObject);
            
            // Taasta lennuk algusesse
            transform.position = startPosition;
            transform.rotation = startRotation;
            
            // Väike viivitus enne taastamist
            GetComponent<Collider>().enabled = false;
            Invoke("EnableCollider", 1f);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            // Efektid
            if (scoreEffect != null)
                Instantiate(scoreEffect, other.transform.position, Quaternion.identity);
            
            if (scoreSound != null)
                audioSource.PlayOneShot(scoreSound);
            
            // Lisa skoor
            if (scoreManager != null)
                scoreManager.AddScore(10);
            
            // Hävita skooritsoon
            Destroy(other.gameObject);
        }
    }
    
    void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }
}