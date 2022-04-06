using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAI : MonoBehaviour
{
   public NavMeshAgent NavMesh;

    public Transform waypoint;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.GetComponent<NavMeshAgent>() != null)
        {
            NavMesh = this.gameObject.GetComponent<NavMeshAgent>();
        }
        if(waypoint != null)
        {
            NavMesh.destination = waypoint.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
