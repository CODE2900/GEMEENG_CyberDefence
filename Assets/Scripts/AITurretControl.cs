using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurretControl : MonoBehaviour
{
    public Turret TurretParent; 
    public TowerTargeting Targeting;
    public LookTarget AutoLook;
    //public Transform FirePoint;
    public float FireTime;
    private float fireTimer;

    private void Awake()
    {
        TurretParent = this.gameObject.GetComponent<Turret>();
        FireTime = 1/TurretParent.FireRate;
        AutoLook = this.gameObject.GetComponentInChildren<LookTarget>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Targeting.targets.Count > 0)
        {
            //TurretHead.transform.LookAt(Targeting.targets[0].transform);
            if(fireTimer >= FireTime)
            {
                AutomaticShoot();
                fireTimer = 0;
            }
            else
            {
                fireTimer += Time.deltaTime;
            }
        }
        else
        {
            fireTimer = 0;
        }
        
    }

    public void AutomaticShoot()
    {
        TurretParent.AutoFire();
    }

}
