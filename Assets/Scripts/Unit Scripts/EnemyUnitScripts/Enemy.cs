using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [Header("Enemy AI Movement")]
    public List<GameObject> waypoints;
    [SerializeField]
    int currentWaypoint = 0;
    public float minDistanceToWaypoint = 0.1f;
    public float movementSpeed = 1f;
    [SerializeField]
    Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();  
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWaypoint();
    }

    private void FixedUpdate()
    {
        
    }

    void MoveToWaypoint() {
        if(currentWaypoint < waypoints.Count)
        {
            if (!IsEnemyNearWaypoint())
            {
                Debug.Log(waypoints[currentWaypoint].transform.position);
                this.gameObject.transform.LookAt(waypoints[currentWaypoint].transform);
                //rigidBody.MovePosition(this.gameObject.transform.position);
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, waypoints[currentWaypoint].transform.position, movementSpeed * Time.deltaTime);
               
            }
            else
            {
                currentWaypoint++;
            }
            
        }
        
        
    }
    bool IsEnemyNearWaypoint()
    {
        float distance = Vector3.Distance(rigidBody.transform.position, waypoints[currentWaypoint].transform.position);
        Debug.Log("Distance between enemy and waypoint: " + distance);
        return distance <= minDistanceToWaypoint; 
    }
}
