using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 25.0f;
    [SerializeField] float rotationSpeed = 100.0F;
    [SerializeField] Vector3 direction;
    [SerializeField] Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            rb = this.gameObject.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
