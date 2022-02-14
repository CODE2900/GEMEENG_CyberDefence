using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum firingMode
{
    ManualMode,
    FiringMode
}

public class Turret : Unit
{
    public string name;
    public float fireRate;
    public GameObject projectile; 
    public GameObject turretHead;
    public float recoil;
    public float spread;
    float damage;

    
    [Header("Targets")]
    public TowerTargeting Targeting;
    public Transform FirePoint;

    public float fireTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(Firing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(Targeting.target == true)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (fireTime <= 0)
        {
            Debug.Log("Turret Shooting");
            Targeting.target.GetComponentInParent<HealthComponent>().onHit.Invoke(10);
            fireTime = 10.0f;
        }
        else
        {
            fireTime -= Time.deltaTime;
        }

       
    }

   
}
