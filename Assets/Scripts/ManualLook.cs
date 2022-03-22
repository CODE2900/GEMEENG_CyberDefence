using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualLook : MonoBehaviour
{
    public float mouseSensitivity;
    public float XRotation = 0f;
    public float YRotation = 0f;
    public Transform TurretHead;
    private Camera turretCamera;
    private GameObject firePoint;


    // Start is called before the first frame update
    void Start()
    {
        turretCamera = this.gameObject.GetComponent<Camera>();  

    }

    // Update is called once per frame
    void Update()
    {
        if (turretCamera.enabled)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            XRotation -= mouseY;
            XRotation = Mathf.Clamp(XRotation, -45f, 45f);

            YRotation += mouseX;

            this.gameObject.transform.rotation = Quaternion.Euler(XRotation, YRotation, 0f);
            TurretHead.transform.rotation = this.gameObject.transform.rotation;
           
        }
        
    }
}
