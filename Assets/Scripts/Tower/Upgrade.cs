using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    virtual public void ActivateUpgrade(GameObject target, GameObject source = null)
    {
        OnActiveUpgrade(target);
    }
    virtual public void DeactivateUpgrade(GameObject target, GameObject source = null)
    {
        OnDeactiveUpgrade(target);
    }
    virtual public void OnActiveUpgrade(GameObject target, GameObject source = null)
    {

    }
    virtual public void OnDeactiveUpgrade(GameObject target, GameObject source = null)
    {

    }
}
