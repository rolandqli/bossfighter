
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;          
    public Vector3 offset = new Vector3(0, 2, -4);
    public float sensitivity = 5f;
    public float distance = 4f;
    public float smoothSpeed = 10f;
    public float minY = -35f, maxY = 60f;

    private float rotationY;
    private float rotationX;

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);

        // Calculate rotation and position
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Smooth camera movement
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f); 
    }
}

