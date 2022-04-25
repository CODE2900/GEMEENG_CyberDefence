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
    //public float FireRate;
    public GameObject Projectile; 
    public GameObject TurretHead;
    //public float Recoil;
    //public float Spread;
    //public float Damage;
    public TurretAttributes Attributes;
    //public int Level;
    public ParticleSystem ShootingParticle;
    public GameObject Status;

    public List<Skill> TurretSkills = new();
    public List<GameObject> FiringModes = new();
    
    [Header("Targets")]
    public TowerTargeting Targeting;
    public Transform FirePoint;

    //[Header("Sounds")]
    //public AudioSource shootingSFX;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public virtual void AutoFire()
    {

       
    }

    public virtual void ManualShooting()
    {

    }
    
}
