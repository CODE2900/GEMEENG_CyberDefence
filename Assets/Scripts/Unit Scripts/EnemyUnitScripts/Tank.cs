using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Tank : Unit
{
    public GameObject FirePoint;
    public bool isStun;

    public float Damage;
    // Start is called before the first frame update
   
    public void ShootTarget()
    {
        Debug.Log("Shooting Target");
        RaycastHit Hit;
        Assert.IsNotNull(FirePoint, "There is no FirePoint set");

        //Targeting Targeting = this.gameObject.GetComponent<Targeting>();
        //if (Targeting)
        //{
        //    HealthComponent TargetHealth = Targeting.Target.GetComponent<HealthComponent>();
        //    if (TargetHealth)
        //    {
        //        TargetHealth.OnHit.Invoke(Damage);
        //    }
        //}
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out Hit, AttackRange))
        {
            Debug.Log("Hit: " + Hit.transform.name);
            MainBase UnitHit = Hit.transform.GetComponent<MainBase>();
            if (UnitHit)
            {
                Health UnitHitHealth = UnitHit.GetComponent<Health>();
                if (UnitHitHealth)
                {
                    UnitHitHealth.TakeDamage(Damage);
                    Debug.Log("Shooting Target: " + Hit.transform.gameObject.name);
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
