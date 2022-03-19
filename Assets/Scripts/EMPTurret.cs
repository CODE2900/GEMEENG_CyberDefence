using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPTurret : Turret
{
    public GameObject MineSpawnPoint;
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
        if (Projectile)
        {
            GameObject EMPBullet = Instantiate(Projectile, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }

    public override void AutoFire()
    {
        if (Projectile)
        {
            GameObject EMPBullet = Instantiate(Projectile, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }
}
