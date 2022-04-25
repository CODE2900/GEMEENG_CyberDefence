using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpeederEnemy : Enemy
{
    //public GameObject FirePoint;
    //public bool isStun;

    //public float Damage;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

    }



    //public void ShootTarget()
    //{
    //    Debug.Log("Shooting Target");
    //    RaycastHit Hit;
    //    Assert.IsNotNull(FirePoint, "There is no FirePoint set");

    //    if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out Hit, AttackRange))
    //    {
    //        Debug.Log("Hit: " + Hit.transform.name);
    //        MainBase UnitHit = Hit.transform.GetComponent<MainBase>();
    //        if (UnitHit)
    //        {
    //            Health UnitHitHealth = UnitHit.GetComponent<Health>();
    //            if (UnitHitHealth)
    //            {
    //                UnitHitHealth.TakeDamage(Damage);
    //                Debug.Log("Shooting Target: " + Hit.transform.gameObject.name);
    //            }
    //        }
    //        Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward, Color.red, 2);
    //    }

    //}

    public override void ShootTarget()
    {
        base.ShootTarget();
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }

    public override void Initialize()
    {
        base.Initialize();
    }
}
