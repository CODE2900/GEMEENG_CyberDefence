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

        if (targets.Count > 0 && targets[0] == null)
        {

            targets.Remove(targets[0].gameObject);

        }
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

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
        //target = null;
    }

}
