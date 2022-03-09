using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGunSkill : Skill
{
    public float IncreaseFireRate;
    public bool isActivated = false;
    public float Duration;
    public float DurationTimer; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if(DurationTimer < Duration)
            {
                DurationTimer += Time.deltaTime;
            }
            else
            {
                DeactivateSkill(TargetUnit);
                DurationTimer = 0;
            }
        }
        
    }

    public override void ActivateSkill(GameObject target, GameObject source = null)
    {
        base.ActivateSkill(target, source);
    }
    public override void DeactivateSkill(GameObject target, GameObject source = null)
    {
        base.DeactivateSkill(target, source);
    }
    public override void OnActivateSkill(GameObject target, GameObject source = null)
    {
        isActivated = true;
        Turret turretTarget = target.GetComponent<Turret>();
        if (turretTarget)
        {
            TargetUnit = turretTarget.gameObject;
            turretTarget.fireRate *= IncreaseFireRate;
            Debug.Log("Increased FireRate to : " + turretTarget.fireRate);
        }
    }

    public override void OnDeactivateSkill(GameObject target, GameObject source = null)
    {
        isActivated = false;
        Turret turretTarget = target.GetComponent<Turret>();
        if (turretTarget)
        {
            turretTarget.fireRate /= IncreaseFireRate;
            Debug.Log("Decreased FireRate to : " + turretTarget.fireRate);
        }
    }

}
