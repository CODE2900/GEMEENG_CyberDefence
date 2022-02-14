using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    // List<GameObject> targets;
    public GameObject target;
    public Turret turret;
    //public Collider collider;

    // Start is called before the first frame update
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
    }

    //public void LookAtTarget(Transform turretTarget)
    //{
    //    this.transform.LookAt(turretTarget);
    //}

    private void OnTriggerEnter(Collider other)
    {
        //targets.Add(other.gameObject);

        //if (other.gameObject.GetComponentInParent<Player>() != null)
        //{
        //    targets.Add(other.gameObject);
        //}
        target = other.transform.parent.gameObject;

    }

    private void OnTriggerExit(Collider other)
    {
        //targets.Remove(other.gameObject);
        target = null;
    }

}
