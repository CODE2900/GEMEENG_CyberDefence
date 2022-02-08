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
        if (TowerTargets.targets != null)
        {
            LookAtTarget(TowerTargets.targets[0].transform);
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
