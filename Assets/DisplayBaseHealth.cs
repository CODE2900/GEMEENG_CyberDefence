using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DisplayBaseHealth : MonoBehaviour
{
    public Health BaseHealth;
    public Slider HealthSlider;

    void Awake()
    {
        //Initialize();
    }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void UpdateHealthBar()
    {
        Assert.IsNotNull(HealthSlider, "Health slider is not set");
        HealthSlider.maxValue = BaseHealth.MaxHP;
        HealthSlider.value = BaseHealth.CurrentHP;
        
        Debug.Log("Base Current Health: " + BaseHealth.CurrentHP);
        Debug.Log("Updated Health Slider: " + "Max HP: " + HealthSlider.maxValue + " Current Health Value: " + HealthSlider.value);
    }

    void Initialize()
    {
        Assert.IsNotNull(BaseHealth, "Base health is null or empty");
        BaseHealth.OnTakeDamage.AddListener(UpdateHealthBar);
        if(HealthSlider == null)
        {
            HealthSlider = this.GetComponent<Slider>();
        }
        Assert.IsNotNull(HealthSlider, "Health slider is not set");
        UpdateHealthBar();
       
        
    }

}
