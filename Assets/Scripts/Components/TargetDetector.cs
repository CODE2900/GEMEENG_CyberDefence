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
        MainBase unitCollided = other.GetComponent<MainBase>();
        if (unitCollided)
        {
            
           
           unit.GetComponent<Targeting>().Target = unitCollided.gameObject;
           
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MainBase unitCollided = other.GetComponent<MainBase>();
        if (unitCollided == unit.GetComponent<Targeting>().Target)
        {

            unit.GetComponent<Targeting>().Target = null;
            

        }
    }


}
