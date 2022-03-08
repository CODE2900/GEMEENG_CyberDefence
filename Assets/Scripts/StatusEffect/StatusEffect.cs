using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    [SerializeField]
    public GameObject targetUnit;

    [SerializeField]
    protected string buffName;
    //[SerializeField]
    //protected UnitStats buffStats;

    virtual public void ActivateStatusEffect(GameObject target, GameObject source = null)
    {
        OnActiveBuff(target);
    }
    virtual public void DeactivateStatusEffect(GameObject target, GameObject source = null)
    {
        OnDeactiveBuff(target);
    }
    virtual public void OnActiveBuff(GameObject target, GameObject source = null)
    {

    }
    virtual public void OnDeactiveBuff(GameObject target, GameObject source = null)
    {

    }
}
