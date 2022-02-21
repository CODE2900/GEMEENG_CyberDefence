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

    public ParticleSystem ShootingParticle;
    
    [Header("Targets")]
    public TowerTargeting Targeting;
    public Transform FirePoint;

    [SerializeField] private float fireTime = 1.5f;

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
        if(Targeting.targets[0] != null)
        {
            Shoot();
        }
        else
        {
            ShootingParticle.Stop();
            fireTime = 1.5f;
        }
    }

    public void Shoot()
    {
        if (fireTime <= 0)
        {
            Debug.Log("Turret Shooting");
            Targeting.targets[0].GetComponentInParent<HealthComponent>().OnHit.Invoke(10);
            fireTime = 1.5f;
            ShootingParticle.Play();
        }
        else
        {
            fireTime -= Time.deltaTime;
        }

       
    }

   
}
