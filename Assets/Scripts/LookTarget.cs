using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{

    [Header("Public Var")]
    public TowerTargeting TowerTargets;
    public int RotationSpeed;

    [Header("Tansform")]
    Vector3 relativePosition;
    Quaternion targetRotation;


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
        relativePosition = turretTarget.position - this.transform.position;
        targetRotation = Quaternion.LookRotation(relativePosition);

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
        //this.transform.LookAt(turretTarget);
    }

}
