using UnityEngine;

public class NewCamera : MonoBehaviour
{
    public Transform target; 
    public Transform pivot;  
    public Transform cam; 

    public float distance = 5f;
    public float mouseSensitivity = 3f;
    public float smoothTime = 0.1f;

    private Vector2 rotation = Vector2.zero;
    private Vector3 currentVelocity;

    void LateUpdate()
    {
        if (!target) return;

        // Follow player
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref currentVelocity, smoothTime);

        // Mouse input
        rotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -35f, 60f); 

        // Apply rotations
        transform.rotation = Quaternion.Euler(0, rotation.x, 0);
        pivot.localRotation = Quaternion.Euler(rotation.y, 0, 0);

        // Set camera position behind the pivot
        cam.localPosition = new Vector3(0, 0, -distance);
    }
}
