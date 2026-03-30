using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    
    [Header("Positsioon")]
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;
    
    [Header("Rotatsioon")]
    public bool followRotation = false;
    public Vector3 rotationOffset = new Vector3(15, 0, 0);
    
    [Header("Sujuvus")]
    public bool useSmoothing = true;
    
    void LateUpdate()
    {
        if (target == null)
        {
            // Proovi automaatselt leida lennukit
            GameObject plane = GameObject.FindGameObjectWithTag("Player");
            if (plane != null)
                target = plane.transform;
            else
                return;
        }
        
        if (useSmoothing)
        {
            // Sujuv järgimine (Lerp)
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else
        {
            // Kohene järgimine
            transform.position = target.position + offset;
        }
        
        // Kaamera rotatsioon
        if (followRotation)
        {
            transform.rotation = target.rotation * Quaternion.Euler(rotationOffset);
        }
        else
        {
            transform.rotation = Quaternion.Euler(rotationOffset);
        }
    }
}