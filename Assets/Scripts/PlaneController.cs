using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Kiirus")]
    public float baseSpeed = 25f;
    public float boostSpeed = 45f;
    public float slowSpeed = 15f;
    private float currentSpeed;
    
    [Header("Pööramine")]
    public float turnSpeed = 100f;
    public float pitchSpeed = 100f;
    
    void Start()
    {
        currentSpeed = baseSpeed;
    }
    
    void Update()
    {
        // === KIIRUSE MUUTMINE ===
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = slowSpeed;
        }
        else
        {
            currentSpeed = baseSpeed;
        }
        
        // === EDASILIIKUMINE (negatiivne X, et minna õiget pidi) ===
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        
        // === JUHTIMINE ===
        float horizontal = Input.GetAxis("Horizontal");  // A/D või vasak/parem
        float vertical = Input.GetAxis("Vertical");      // W/S või üles/alla
        
        // Pööramine
        transform.Rotate(Vector3.forward, -vertical * turnSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontal * pitchSpeed * Time.deltaTime);
    }
}