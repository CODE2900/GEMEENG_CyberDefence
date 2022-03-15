using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountable : MonoBehaviour
{
    [Header("Turret")]
    public Turret TurretParent;
    public GameObject TurretHead;
    public GameObject CameraMount;
    public Camera TurretCamera;
    public GameObject FirePoint;
    
    public BoxCollider InteractCollider;

    [Header("Input")]
    public bool isMounted = false;
    public float InteractTime = 1;
    

    [Header("Player")]
    public GameObject Player;

    private float interactTimer = 0; 
    private Coroutine particleEffectRoutine;
    private RaycastHit hit;
    private float FireTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        TurretParent = this.gameObject.transform.parent.GetComponent<Turret>();
        TurretCamera.enabled = false;
        isMounted = false;
        InteractCollider = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TurretCamera.enabled)
        {
            
            if (Input.GetButton("Fire1")) {
                if(FireTimer >= TurretParent.GetComponent<Turret>().FireRate)
                {
                    //particleEffectRoutine = StartCoroutine(PlayShootingParticles());
                    Debug.Log("Fire button down");
                    TurretParent.ManualShooting();//Shoot();
                    FireTimer = 0;
                }
                else
                {
                    FireTimer += Time.deltaTime;
                }
               
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                TurretParent.GetComponent<Turret>().TurretSkills[0].ActivateSkill(TurretParent.gameObject);
            }
            if (isMounted)
            {
                if (Input.GetKey(KeyCode.F))
                {
                    if (interactTimer >= InteractTime)
                    {
                        Debug.Log("Unmount");
                        isMounted = false;
                        TurretCamera.enabled = false;
                        Player.SetActive(true);
                        Player.GetComponent<Player>().PlayerCamera.enabled = true;
                        InteractCollider.enabled = true;
                        interactTimer = 0;
                        Player = null;
                    }
                    else
                    {
                        interactTimer += Time.deltaTime;
                    }

                }
            }


        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        Player player = other.gameObject.GetComponentInParent<Player>();
        if (player)
        {
            if (!isMounted)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("Mounted Turret");
                    Player = player.gameObject;
                    player.PlayerCamera.enabled = false;
                    Player.SetActive(false);
                    isMounted = true;
                    TurretCamera.enabled = true;
                    
                    InteractCollider.enabled = false;
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
                    enemyHealth.TakeDamage(TurretParent.Damage);
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
