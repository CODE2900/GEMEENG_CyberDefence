using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_AI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMesh;

    public Transform waypoint;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.GetComponent<NavMeshAgent>() != null)
        {
            navMesh = this.gameObject.GetComponent<NavMeshAgent>();
        }
        navMesh.destination = waypoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
