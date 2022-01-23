using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Keyboard")]
    [SerializeField] float speed = 25.0f;
    [SerializeField] float rotationSpeed = 100.0F;
    [SerializeField] Vector3 direction;
    [SerializeField] Rigidbody rb;



    [Header("Mouse")]
    public float mouseSensitivity = 100.0f;
    public float xRotation = 0f;

    //[Header("Camera")]
    //public Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (this.gameObject.GetComponent<Rigidbody>() != null)
        {
            rb = this.gameObject.GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //xRotation -= mouseY;
        //xRotation = Mathf.Clamp(xRotation, -45f, 45f);

        //camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //this.gameObject.transform.Rotate(Vector3.up * mouseX);




    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
