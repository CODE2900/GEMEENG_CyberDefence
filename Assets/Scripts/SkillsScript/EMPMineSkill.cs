using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPMineSkill : Skill
{
    public GameObject EMPMinePrefab; 

    // Start is called before the first frame update
    void Start()
    {
        
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
        GameObject EMPMine = Instantiate(EMPMinePrefab, target.GetComponent<EMPTurret>().MineSpawnPoint.transform.position, Quaternion.identity);
    }

    public override void OnDeactivateSkill(GameObject target, GameObject source = null)
    {
        
    }

}
