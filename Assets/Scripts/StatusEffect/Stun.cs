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

    public override void OnActiveStatusEffect(GameObject target, GameObject source = null)
    {
        StunValue = target.gameObject.GetComponentInParent<NavMeshAI>().NavMesh.speed;
        target.gameObject.GetComponentInParent<NavMeshAI>().NavMesh.speed -= StunValue;
        target.gameObject.GetComponentInParent<Enemy>().isStun = true ;
        poisonRoutine = StartCoroutine(DestroyStun());

    }
    public override void OnDeactiveStatusEffect(GameObject target, GameObject source = null)
    {
        target.gameObject.GetComponentInParent<NavMeshAI>().NavMesh.speed += StunValue;
        target.gameObject.GetComponentInParent<Enemy>().isStun = false;
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
