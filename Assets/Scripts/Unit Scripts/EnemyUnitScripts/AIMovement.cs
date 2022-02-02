using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    GameObject unit; 
    [Header("Enemy AI Movement")]
    public List<GameObject> waypoints;
    [SerializeField]
    int currentWaypoint = 0;
    public float minDistanceToWaypoint = 0.1f;
    public float movementSpeed = 1f;
    public float rotationSpeed = 1f;
    [SerializeField]
    Rigidbody rigidBody;

    private void Awake()
    {
        unit = this.gameObject;
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void MoveToWaypoint()
    {
        if (currentWaypoint < waypoints.Count)
        {
            if (!IsEnemyNearWaypoint())
            {
                Debug.Log(waypoints[currentWaypoint].transform.position);
                this.gameObject.transform.LookAt(waypoints[currentWaypoint].transform);
                //Vector3 waypointPos = waypoints[currentWaypoint].transform.position;
                //waypointPos.y = 0; // use raycast at the bottom of the model. Use hit.point for the Y pos.
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, waypoints[currentWaypoint].transform.position, movementSpeed * Time.deltaTime);

            }
            else
            {
                currentWaypoint++;
            }

        }


    }
    public bool IsEnemyNearWaypoint()
    {
        float distance = Vector3.Distance(rigidBody.transform.position, waypoints[currentWaypoint].transform.position);
        //Debug.Log("Distance between enemy and waypoint: " + distance);
        return distance <= minDistanceToWaypoint;
    }
    public bool IsLastWaypoint()
    {
        return currentWaypoint >= waypoints.Count - 1;
    }
}
