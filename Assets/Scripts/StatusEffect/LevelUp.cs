using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : Upgrade
{
    public override void ActivateUpgrade(GameObject target, GameObject source = null)
    {
        base.ActivateUpgrade(target, source);
    }

    public override void DeactivateUpgrade(GameObject target, GameObject source = null)
    {
        base.DeactivateUpgrade(target, source);
    }

    public override void OnActiveUpgrade(GameObject target, GameObject source = null)
    {
        target.gameObject.GetComponentInParent<Turret>().Level += 1;
    }
    public override void OnDeactiveUpgrade(GameObject target, GameObject source = null)
    {
    }

}
