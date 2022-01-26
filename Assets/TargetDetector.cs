using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    public GameObject unit;
    SphereCollider sphereCollider;
    // Start is called before the first frame update
    void Start()
    {
        unit = this.gameObject.transform.parent.gameObject;
        sphereCollider = this.gameObject.GetComponent<SphereCollider>();
        //sphereCollider.radius = unit.GetComponent<Enemy>().range;
    }

    private void OnTriggerEnter(Collider other)
    {
        Unit unitCollided = other.GetComponent<Unit>();
        if (unitCollided)
        {
            MainBase baseTarget = unitCollided.gameObject.GetComponent<MainBase>();
            if (baseTarget)
            {
                unit.GetComponent<Enemy>().Target = baseTarget.gameObject;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Unit unitCollided = other.GetComponent<Unit>();
        if (unitCollided)
        {
            MainBase baseTarget = unitCollided.gameObject.GetComponent<MainBase>();
            if (baseTarget)
            {
                unit.GetComponent<Enemy>().Target = null;
            }

        }
    }


}
