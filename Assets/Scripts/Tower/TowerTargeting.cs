using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    public List<GameObject> targets;

    //public Collider collider;

   // public GameObject target;
    public Turret turret;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (targets[0] != null)
        //{
        //    LookAtTarget(targets[0].transform);
        //}
        if(targets.Count > 0)
        {
            if (targets[0] == null)
            {
                targets.Remove(targets[0].gameObject);
            }
        }
       

       //if(!turret.isActiveAndEnabled)
       //{
       //     targets.Clear();
       //}
    }

    //public void LookAtTarget(Transform turretTarget)
    //{
    //    this.transform.LookAt(turretTarget);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<Enemy>() != null)
        {
            targets.Add(other.transform.parent.gameObject);
        }
   

        //if(other.gameObject.GetComponentInParent<Enemy>() != null)
        //{
        //    target = other.transform.parent.gameObject;
        //}
        
    }


    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
        //target = null;
    }

}
