using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    public TowerTargeting TowerTargets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (TowerTargets.target != null)
        {
            LookAtTarget(TowerTargets.target.transform);
        }
        else
        {
            Debug.Log("No Target");
        }
      
    }
    public void LookAtTarget(Transform turretTarget)
    {
        this.transform.LookAt(turretTarget);
    }

}
