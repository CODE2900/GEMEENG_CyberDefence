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
    public string ID; 
    public float FireRate;
    public GameObject Projectile; 
    public GameObject TurretHead;
    public float Recoil;
    public float Spread;
    public float Damage;
    //public int Level;
    public ParticleSystem ShootingParticle;
    public GameObject Status;

    public List<Skill> TurretSkills = new();
    public List<GameObject> FiringModes = new();
    
    [Header("Targets")]
    public TowerTargeting Targeting;
    public Transform FirePoint;

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
        //if(Targeting.targets.Count > 0)
        //{
        //    AutoFire();
        //}
        //else
        //{
        //    //if (ShootingParticle)
        //    //{
        //    //    //ShootingParticle.Stop();
        //    //}
            
        //    fireTime = 1.5f;
        //}
    }

    public virtual void AutoFire()
    {
        //if (fireTime <= 0)
        //{
        //    if(Projectile == null)
        //    {
        //        Debug.Log("Turret Shooting");
        //        if (ShootingParticle)
        //        {
        //            ShootingParticle.Play();
        //        }
                
        //        Targeting.targets[0].GetComponentInParent<Health>().OnHit.Invoke(Damage);
        //        fireTime = 1.5f;
        //    }
        //    else
        //    {
        //        GameObject EMPBullet = Instantiate(Projectile, FirePoint.transform.position, FirePoint.transform.rotation);
        //        fireTime = 1.5f;
        //    }
        //}
        //else
        //{
        //    fireTime -= Time.deltaTime;
        //}

       
    }

    public virtual void ManualShooting()
    {

    }

    
}
