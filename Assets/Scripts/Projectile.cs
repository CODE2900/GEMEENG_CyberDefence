using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject EMP;
    public Rigidbody rb;
    public int ProjectileSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, Time.deltaTime * ProjectileSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(EMP, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

   
}
