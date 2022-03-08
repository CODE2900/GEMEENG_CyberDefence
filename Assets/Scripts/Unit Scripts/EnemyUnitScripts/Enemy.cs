using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : Unit
{
    public GameObject FirePoint;
    
    public void ShootTarget()
    {
        Debug.Log("Shooting Target");
        RaycastHit Hit;
        Assert.IsNotNull(FirePoint, "There is no FirePoint set");

        Targeting Targeting = this.gameObject.GetComponent<Targeting>();
        if (Targeting)
        {
            HealthComponent TargetHealth = Targeting.Target.GetComponent<HealthComponent>();
            if (TargetHealth)
            {
                TargetHealth.OnHit.Invoke(Damage);
            }
        }
       
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }
}
