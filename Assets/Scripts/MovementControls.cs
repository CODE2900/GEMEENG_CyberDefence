using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControls : MonoBehaviour
{
    [Header("Keyboard")]
    [SerializeField] float speed = 25.0f;
    // [SerializeField] float rotationSpeed = 100.0F;
    [SerializeField] Vector3 move;
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            rb = this.gameObject.GetComponent<Rigidbody>();
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        rb.MovePosition(transform.position + (move * speed * Time.deltaTime));
    }
}
