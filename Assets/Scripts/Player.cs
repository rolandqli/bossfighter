using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Debug.Log(x);
        Debug.Log(z);

        rb.MovePosition(rb.position + new Vector3(x,0,z) * moveSpeed * Time.fixedDeltaTime);

    }
}
