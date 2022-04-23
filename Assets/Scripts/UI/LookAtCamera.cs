using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
     public Transform playerCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerCameraTransform = SingletonManager.Get<GameManager>().playerCamera;
    }

    private void LateUpdate()
    {
        if (playerCameraTransform)
        {
            transform.LookAt(this.transform.position + playerCameraTransform.forward);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
