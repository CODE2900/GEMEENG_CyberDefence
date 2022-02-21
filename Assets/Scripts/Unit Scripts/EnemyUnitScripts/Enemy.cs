using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : Unit
{
    public GameObject FirePoint;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    private void FixedUpdate()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        Unit unitCollided = collision.gameObject.GetComponent<Unit>();
        if (unitCollided)
        {
            HealthComponent unitHealthComponent = unitCollided.gameObject.GetComponent<HealthComponent>();
            if (unitHealthComponent)
            {
                unitHealthComponent.TakeDamage(1);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Not Unit collided");
        }
    }

    public void ShootTarget()
    {
        Debug.Log("Shooting Target");
        RaycastHit Hit;
        Assert.IsNotNull(FirePoint, "There is no FirePoint set");
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out Hit, AttackRange))
        {
            Unit UnitHit = Hit.transform.gameObject.GetComponent<Unit>();
            if (UnitHit)
            {
                HealthComponent UnitHitHealth = UnitHit.GetComponent<HealthComponent>();
                if (UnitHitHealth)
                {
                    UnitHitHealth.TakeDamage(Damage);
                }
            }
            Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward, Color.red, 2);
        }


    }

    public override void OnDeath()
    {
        base.OnDeath();
    }
}
