using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string Id;
    public string Name;
    public GameObject TargetUnit;
    public GameObject SourceUnit; 

    public virtual void ActivateSkill(GameObject target, GameObject source = null)
    {
        OnActivateSkill(target, source);
    }

    public virtual void DeactivateSkill(GameObject target, GameObject source = null)
    {
        OnDeactivateSkill(target, source);
    }

    public virtual void OnActivateSkill(GameObject target, GameObject source = null)
    {

    }
    
    public virtual void OnDeactivateSkill(GameObject target, GameObject source = null)
    {

    }
    
}
