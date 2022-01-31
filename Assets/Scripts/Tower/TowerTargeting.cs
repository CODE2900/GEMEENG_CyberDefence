using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTargeting : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            LookAtTarget(target.transform);
        }
    }

    public void LookAtTarget(Transform turretTarget)
    {
        this.transform.LookAt(turretTarget);
    }
}
