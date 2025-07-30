using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    private float currHP;
    public float totalHP;
    public Slider HPSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HPSlider.value = 1;

    }

    public void takeDamage(float damage)
    {
        currHP -= damage;
        HPSlider.value = currHP / totalHP;
        if (currHP < 0)
        {
            Death();
        }
    }

    void Death()
    {

    }

// Update is called once per frame
void Update()
    {
        
    }
}
