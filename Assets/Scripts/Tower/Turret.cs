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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Shoot()
    {
        if(projectile != null)
        {
            if(Targeting.targets[0] != null)
            {
                Instantiate(projectile, FirePoint.transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("No Targets");
                return;
            }
           
        }
    }
   
}
