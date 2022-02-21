using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Unit : MonoBehaviour
{
    public string Id;
    public string Name;
    public float AttackRange = 100f;
    public int Damage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnDeath()
    {

    }

    //For Testing Attack State
    //public void Shoot()
    //{
    //    Debug.Log("Shooting Target");
    //    RaycastHit Hit;
    //    Assert.IsNotNull(FirePoint, "There is no FirePoint set");
    //    if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out Hit, AttackRange))
    //    {
    //        Unit UnitHit = Hit.transform.gameObject.GetComponent<Unit>();
    //        if (UnitHit)
    //        {
    //            HealthComponent UnitHitHealth = UnitHit.GetComponent<HealthComponent>();
    //            if (UnitHitHealth)
    //            {
    //                UnitHitHealth.TakeDamage(Damage);
    //            }
    //        }
    //        Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward, Color.red, 2);
    //    }

    //}
}
