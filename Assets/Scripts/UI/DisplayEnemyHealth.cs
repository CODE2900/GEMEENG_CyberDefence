using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class DisplayEnemyHealth : MonoBehaviour
{
    [SerializeField]
    Slider healthSlider;
    [SerializeField]
    Health healthComponent;

    private void Awake()
    {
        SingletonManager.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider = this.GetComponentInParent<Slider>();
        healthComponent = this.transform.GetComponentInParent<Health>();
        Assert.IsNotNull(healthComponent);
        healthSlider.maxValue = healthComponent.MaxHP;
        healthSlider.value = healthComponent.CurrentHP;
        //SetMaxHealth(healthComponent.GetMaxHP());
    }
    public void SetCurrentHealth(float health)
    {
        healthSlider.value = health;
    }

    public void SetMaxHealth(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
    }

    private void Update()
    {
        healthSlider.value = healthComponent.CurrentHP;
        healthSlider.maxValue = healthComponent.MaxHP;
    }
}
