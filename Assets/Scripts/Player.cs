using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    private float currHP;
    public float totalHP;
    public Slider HPSlider;


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
        rb.MovePosition(rb.position + new Vector3(x,0,z) * moveSpeed * Time.fixedDeltaTime);

    }
}
