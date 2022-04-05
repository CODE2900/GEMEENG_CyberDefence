using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Mouse")]
    public float MouseSensitivity = 100.0f;
    public float XRotation = 0f;
    public GameObject Player;
    

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        #region mouseControls
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -45f, 45f);

        this.gameObject.transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
        Player.transform.Rotate(Vector3.up * mouseX);
        #endregion

        #region raycasting
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(this.transform.position, forward, Color.red);

        if (Physics.Raycast(this.transform.position, forward, out hit, 10))
        {
            Debug.DrawRay(this.transform.position, forward, Color.green);
           // Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.GetComponent<Interactable>() != null)
            {
                hit.collider.gameObject.GetComponent<Interactable>().InvokeInteract();
                hit.collider.gameObject.GetComponent<Interactable>().Interact(Player);
            }
            else
            {
                SingletonManager.Get<UIManager>().InteractUI.GetComponent<DisplayInteractMessage>().RemoveMessageText();
            }
            
            
        }
        #endregion
    }
}
