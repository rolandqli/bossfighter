using UnityEngine;

public class Kick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        GameObject obj = collision.gameObject;
        Debug.Log("Triggered by " + obj.name);
        if (obj.name == "Enemy")
        {
            obj.GetComponent<Boss>().takeDamage(3);
        }
    }
}
