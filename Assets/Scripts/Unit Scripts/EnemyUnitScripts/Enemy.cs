using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : Unit
{
    public GameObject FirePoint;
    public bool isStun;
    public Health Health; 
    public float Damage;
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



    //private void OnCollisionEnter(Collision collision)
    //{
    //    Unit unitCollided = collision.gameObject.GetComponent<Unit>();
    //    if (unitCollided)
    //    {
    //        HealthComponent unitHealthComponent = unitCollided.gameObject.GetComponent<HealthComponent>();
    //        if (unitHealthComponent)
    //        {
    //            unitHealthComponent.TakeDamage(1);
    //            Destroy(this.gameObject);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("Not Unit collided");
    //    }
    //}

    public virtual void ShootTarget()
    {
        Debug.Log("Shooting Target");
        RaycastHit Hit;
        Assert.IsNotNull(FirePoint, "There is no FirePoint set");

        Targeting Targeting = this.gameObject.GetComponent<Targeting>();
        if (Targeting)
        {
            Health TargetHealth = Targeting.Target.GetComponent<Health>();
            if (TargetHealth)
            {
                TargetHealth.OnHit.Invoke(Damage);
            }
        }
        //if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out Hit, AttackRange))
        //{
        //    Debug.Log("Hit: " + Hit.transform.name);
        //    MainBase UnitHit = Hit.transform.gameObject.GetComponent<MainBase>();
        //    if (UnitHit)
        //    {
        //        Health UnitHitHealth = UnitHit.GetComponent<Health>();
        //        if (UnitHitHealth)
        //        {
        //            UnitHitHealth.TakeDamage(Damage);
        //            Debug.Log("Shooting Target: " + Hit.transform.gameObject.name);
        //        }
        //    }
        //    Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward, Color.red, 2);
        //}

    }

    public override void OnDeath()
    {
        //base.OnDeath();
        SingletonManager.Get<GameManager>().EnemyKilled++;
        SingletonManager.Get<WaveManager>().CheckForEnemies();
    }

    public override void Initialize()
    {
        //base.Initialize();
        if(Health == null)
        {
            Health = this.GetComponent<Health>();
        }
        Health.OnDeath.AddListener(this.OnDeath);

    }
}
