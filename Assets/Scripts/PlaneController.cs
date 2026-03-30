using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [Header("Liikumine")]
    public float forwardSpeed = 30f;
    public float rotationSpeed = 100f;
    
    [Header("Kiirendamine")]
    public float boostSpeed = 50f;
    public float normalSpeed = 30f;
    public float slowSpeed = 15f;
    
    private float currentSpeed;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
        currentSpeed = forwardSpeed;
    }
    
    void Update()
    {
        // Kiirendamine (Shift) ja aeglustamine (Ctrl)
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
            currentSpeed = normalSpeed;
        }
        
        // Edasi liikumine
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        
        // Pööramine (A/D või vasak/parem)
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
        
        // Kallutamine (W/S või üles/alla)
        float vertical = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, -vertical * rotationSpeed * Time.deltaTime);
    }
}