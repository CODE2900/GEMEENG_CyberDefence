using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]
    float currentHP;
    public float CurrentHP { get { return currentHP; } }
    [SerializeField]
    float maxHP;
    public float MaxHP { get { return maxHP; } set { } }

    public UnityEvent<float> OnHit = new UnityEvent<float>();
    public UnityEvent OnDeath = new();
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;

        OnHit.AddListener(TakeDamage);
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
        //this.gameObject.SetActive(false);
        OnDeath.Invoke();
        Destroy(this.gameObject);
    }

    public bool IsDead()
    {
        return currentHP <= 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}