using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;
    private float currHP;
    public float totalHP;
    public Slider HPSlider;
    public Transform cameraTransform;
    public Animator anim;
    private bool isKicking;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Transform child = transform.Find("Rig");
        //if (child != null)
        //{
        //    rb = child.gameObject.GetComponent<Rigidbody>();
        //}
        rb = GetComponent<Rigidbody>();
        Debug.Log(HPSlider);
        HPSlider.value = 1;
        if (HPSlider == null)
        {
            Debug.Log("HPSlider is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if ((x != 0 || z != 0) && !isKicking)
        {
            anim.SetBool("Run", true);

            Vector3 inputDir = new Vector3(x, 0, z);

            Vector3 cameraZ = cameraTransform.forward;
            Vector3 cameraX = cameraTransform.right;
            cameraZ.y = 0f;
            cameraX.y = 0f;
            Vector3 relativeDir = cameraZ * z + cameraX * x;
            Quaternion targetRotation = Quaternion.LookRotation(relativeDir);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            rb.MovePosition(rb.position + relativeDir * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetMouseButtonDown(0)) 
        {

            StartCoroutine(Kick());
        }

        IEnumerator Kick()
        {
            isKicking = true;
            anim.SetTrigger("Kick");
            yield return new WaitForSeconds(1.3f);
            isKicking = false;
        }


        //anim.SetFloat("Speed", speed);s
        


    }
    
}
