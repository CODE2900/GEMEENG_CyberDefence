using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
            HealthComponent enemyHealth = other.gameObject.GetComponentInParent<HealthComponent>();
            enemyHealth.OnDeath.AddListener(OnTargetDeath);
            targets.Add(other.transform.parent.gameObject);
        }
    }

    void OnTargetDeath()
    {
        targets = targets.Where(item => item != null).ToList(); //if the item is not null, it will go to the list else it will clear any null value 
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.gameObject);
        //target = null;
    }

}
