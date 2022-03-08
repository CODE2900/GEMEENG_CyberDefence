using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : StatusEffect
{

    public float StunDuration;
    public float StunTimer = 0;
    public float StunValue;
 

    private Coroutine poisonRoutine;
    // Start is called before the first frame update
    public override void ActivateStatusEffect(GameObject target, GameObject source = null)
    {
        base.ActivateStatusEffect(target, source);
    }

    public override void DeactivateStatusEffect(GameObject target, GameObject source = null)
    {
        base.DeactivateStatusEffect(target, source);
    }

    public override void OnActiveBuff(GameObject target, GameObject source = null)
    {
        StunValue = target.gameObject.GetComponentInParent<NavMesh_AI>().NavMesh.speed;
        target.gameObject.GetComponentInParent<NavMesh_AI>().NavMesh.speed -= StunValue;
    
    }
    public override void OnDeactiveBuff(GameObject target, GameObject source = null)
    {
        target.gameObject.GetComponentInParent<NavMesh_AI>().NavMesh.speed += StunValue;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DestroyStun()
    {
        yield return new WaitForSeconds(StunDuration);

        DeactivateStatusEffect(targetUnit);
    }

}
