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
    public bool isMounted = false;

    private Coroutine particleEffectRoutine;
    private RaycastHit hit;
    private float FireTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        TurretParent = this.gameObject.transform.parent.gameObject;
        TurretCamera.enabled = false;
        isMounted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TurretCamera.enabled)
        {
            
            if (Input.GetButton("Fire1")) {
                if(FireTimer >= TurretParent.GetComponent<Turret>().fireRate)
                {
                    particleEffectRoutine = StartCoroutine(PlayShootingParticles());
                    Debug.Log("Fire button down");
                    Shoot();
                    FireTimer = 0;
                }
                else
                {
                    FireTimer += Time.deltaTime;
                }
               
            }
            Debug.DrawRay(FirePoint.transform.position, FirePoint.transform.forward * 100, Color.green);
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TurretParent.GetComponent<Turret>().turretSkills[0].ActivateSkill(TurretParent);
            }
            //if (isMounted)
            //{
            //    if (Input.GetKey(KeyCode.F))
            //    {
            //        isMounted = false;
            //        TurretCamera.enabled = false;
            //        Player.SetActive(true);
            //        Player.GetComponentInChildren<Camera>().enabled = true;
            //    }
            //}
               
            
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
                if (!isMounted)
                {
                    Debug.Log("Mounted Turret");
                    Player = player.gameObject;
                    player.gameObject.transform.GetComponentInChildren<Camera>().enabled = false;
                    Player.SetActive(false);
                    TurretCamera.enabled = true;
                    isMounted = true;
                }
                
                
            }
        }

    }

   
    public void Shoot()
    {
        if (Physics.Raycast(FirePoint.transform.position, FirePoint.transform.forward, out hit))
        {
            Enemy enemyHit = hit.transform.gameObject.GetComponent<Enemy>();
            if (enemyHit)
            {
                Health enemyHealth = enemyHit.GetComponent<Health>();
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
