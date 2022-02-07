using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    public List<GameObject> targets;
    public Turret turret;
    //public Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        //if(this.gameObject.GetComponent<Collider>() != null)
        //{
        //    collider = this.gameObject.GetComponent<Collider>();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (targets != null)
        {
            LookAtTarget(targets[0].transform);
        }
    }

    public void LookAtTarget(Transform turretTarget)
    {
        this.transform.LookAt(turretTarget);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Player>() !=null)
        {
            targets.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
    }

}
