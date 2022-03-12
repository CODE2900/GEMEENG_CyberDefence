using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualLook : MonoBehaviour
{
    public float mouseSensitivity;
    public float XRotation = 0f;
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
           
           //TurretHead.rotation = Quaternion.Euler(XRotation, TurretHead.rotation.y * mouseY, 0f);
            this.gameObject.transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
            TurretHead.Rotate(Vector3.up * mouseX);
            //TurretHead.localRotation = Quaternion.Euler(XRotation, 1f * mouseX, 0);
            //TurretHead.Rotate(new Vector3(-mouseY, mouseX, 0f));
        }
        
    }
}
