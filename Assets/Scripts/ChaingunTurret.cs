using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaingunTurret : Turret
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
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
                Health enemyHealth = enemyHit.GetComponent<Health>();
                if (enemyHealth)
                {
                    Debug.Log("Manual Shooting");
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}
