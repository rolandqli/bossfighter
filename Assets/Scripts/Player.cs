using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    private float currHP;
    public float totalHP;
    public Slider HPSlider;
    public Transform cameraTransform;
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HPSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(x, 0, z);

        Vector3 cameraZ = cameraTransform.forward;
        Vector3 cameraX = cameraTransform.right;
        cameraZ.y = 0f;
        cameraX.y = 0f;
        Vector3 relativeDir = cameraZ * z + cameraX * x;
        Quaternion targetRotation = Quaternion.LookRotation(relativeDir);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        rb.MovePosition(rb.position + relativeDir * moveSpeed * Time.fixedDeltaTime);
        float speed = rb.linearVelocity.magnitude;
        //anim.SetFloat("Speed", speed);s



    }
}
