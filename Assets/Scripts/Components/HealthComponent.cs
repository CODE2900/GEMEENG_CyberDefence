using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    float currentHP;
    public float CurrentHP { get { return currentHP; } }
    [SerializeField]
    float maxHP;
    public float MaxHP { get { return maxHP; } set { } }   

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1f);
        }
    }
}
