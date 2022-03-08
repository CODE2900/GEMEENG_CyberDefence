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
        OnActiveStatusEffect(target);
    }
    virtual public void DeactivateStatusEffect(GameObject target, GameObject source = null)
    {
        OnDeactiveStatusEffect(target);
    }
    virtual public void OnActiveStatusEffect(GameObject target, GameObject source = null)
    {

    }
    virtual public void OnDeactiveStatusEffect(GameObject target, GameObject source = null)
    {

    }
}
