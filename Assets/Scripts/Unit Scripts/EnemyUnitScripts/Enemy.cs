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
    public float rotationSpeed = 1f;
    [SerializeField]
    Rigidbody rigidBody;

    [Header("Enemy Targeting")]
    [SerializeField]
    GameObject target;
    public GameObject Target { get { return target; } set { target = value; } }
    public float damage = 1;
    public float range = 100f;
    public GameObject firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();  
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            MoveToWaypoint();
        }
        else
        {
            ShootTarget();
        }
        
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
                //this.gameObject.transform.rotation = Quaternion.LookRotation(waypoints[currentWaypoint].transform.position, Vector3.forward);
                //Vector3 targetDirection = waypoints[currentWaypoint].transform.position - this.gameObject.transform.position;
                //Quaternion rotationToTarget = Quaternion.LookRotation(targetDirection);
                //transform.rotation = rotationToTarget;
                //this.gameObject.transform.rotation = rotationToTarget;
                //Vector3 lookDirection = Vector3.RotateTowards(this.gameObject.transform.position, targetDirection, 10 * Time.deltaTime, 0);
                //this.gameObject.transform.rotation = Quaternion.LookRotation(lookDirection);
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

    private void OnCollisionEnter(Collision collision)
    {
        Unit unitCollided = collision.gameObject.GetComponent<Unit>();
        if (unitCollided)
        {
            HealthComponent unitHealthComponent = unitCollided.gameObject.GetComponent<HealthComponent>();
            if (unitHealthComponent)
            {
                unitHealthComponent.TakeDamage(1);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Not Unit collided");
        }
    }

    public void ShootTarget()
    {
        RaycastHit hit;
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            Debug.Log("Object Hit: " + hit.transform.name);
        }
        

    }

}
