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

            
           
           //TurretHead.rotation = Quaternion.Euler(XRotation, TurretHead.rotation.y * mouseY, 0f);
            this.gameObject.transform.rotation = Quaternion.Euler(XRotation, YRotation, 0f);
            TurretHead.transform.rotation = this.gameObject.transform.rotation;
            //TurretHead.transform.localRotation = this.gameObject.transform.localRotation;
            //TurretHead.Rotate(Vector3.up * mouseX);
            //TurretHead.Rotate(new Vector3(XRotation, 0, 0f));
            Debug.Log("Turret Head Rotation: " + TurretHead.rotation);
            //TurretHead.localRotation = Quaternion.Euler(XRotation, 1f * mouseX, 0);
            //TurretHead.Rotate(new Vector3(-mouseY, mouseX, 0f));
        }
        
    }
}
