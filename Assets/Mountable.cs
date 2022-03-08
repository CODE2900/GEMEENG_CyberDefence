using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountable : MonoBehaviour
{
    public GameObject TurretParent;
    public GameObject TurretHead;
    public GameObject CameraMount;
    public Camera TurretCamera;
    public GameObject Player;
    public GameObject FirePoint;
    private float xRotation = 0f;
    private Coroutine particleEffectRoutine;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        TurretParent = this.gameObject.transform.parent.gameObject;
        TurretCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TurretCamera.enabled)
        {
            //Aim();
            if (Input.GetButtonDown("Fire1")) {
                particleEffectRoutine = StartCoroutine(PlayShootingParticles());
                Shoot();
            }
            Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward, Color.green);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        Player player = other.gameObject.GetComponentInParent<Player>();
        if (player)
        {
            if (Input.GetKeyDown(KeyCode.F))
            { 
                Debug.Log("Mounted Turret");
                Player = player.gameObject;
                player.gameObject.transform.GetComponentInChildren<Camera>().enabled = false;
                TurretCamera.enabled = true;
            }
        }

    }

    private void Aim()
    {
        float mouseX = Input.GetAxis("Mouse X") * 100.0f * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * 100.0f * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        TurretHead.transform.localRotation = Quaternion.Euler(xRotation, 0, 0f);
        TurretHead.transform.Rotate(Vector3.up * mouseX);


    }
    public void Shoot()
    {
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            Enemy enemyHit = hit.transform.gameObject.GetComponent<Enemy>();
            if (enemyHit)
            {
                HealthComponent enemyHealth = enemyHit.GetComponent<HealthComponent>();
                if (enemyHealth)
                {
                    Debug.Log("Manual Shooting");
                    enemyHealth.TakeDamage(TurretParent.GetComponent<Turret>().damage);
                }
            }
        }
    }

    IEnumerator PlayShootingParticles()
    {
        TurretParent.GetComponent<Turret>().ShootingParticle.Play();
        yield return new WaitForSeconds(3.0f);
        TurretParent.GetComponent<Turret>().ShootingParticle.Stop();
    }
}
