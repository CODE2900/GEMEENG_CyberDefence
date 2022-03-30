using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaingunTurret : Turret
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ManualShooting()
    {
        Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward * 100, Color.green);
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            Enemy enemyHit = hit.transform.gameObject.GetComponent<Enemy>();
            if (enemyHit)
            {
                Debug.Log("Enemy Hit: " + enemyHit.name);
                Health enemyHealth = enemyHit.GetComponent<Health>();
                if (enemyHealth)
                {
                    Debug.Log("Has health");
                    ShootingParticle.Play(true);
                    Debug.Log("Manual Shooting");
                    enemyHealth.Attacker = SingletonManager.Get<GameManager>().Player;
                    enemyHealth.TakeDamage(Attributes.Damage);
                }
            }
        }
    }

    public override void AutoFire()
    {
        Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward * 100, Color.green);
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            Enemy enemyHit = hit.transform.gameObject.GetComponent<Enemy>();
            if (enemyHit)
            {
                Debug.Log("Enemy Hit: " + enemyHit.name);
                Health enemyHealth = enemyHit.GetComponent<Health>();
                if (enemyHealth)
                {
                    Debug.Log("Has health");
                    if (ShootingParticle)
                    {
                        ShootingParticle.Play();
                    }
                    enemyHealth.Attacker = SingletonManager.Get<GameManager>().Player;
                    enemyHealth.TakeDamage(Attributes.Damage);
                    Debug.Log("Auto Shooting");
                }
            }
        }
    }

    public override void Initialize()
    {
        if(Attributes == null)
        {
            Attributes = this.GetComponent<TurretAttributes>();
        }
    }
}
