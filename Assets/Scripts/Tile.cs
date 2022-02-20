using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] Materials;

    public Interactable Interactable;

    public GameObject[] GhostTurret;
    public GameObject TurretTower;

    [SerializeField] bool isEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        if(Interactable != null)
        {
            Interactable.EvtInteracted.AddListener(Interact);
        }
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        if(isEmpty)
        {
            this.gameObject.GetComponent<Renderer>().material = Materials[0];
            GhostTurret[0].SetActive(false);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = Materials[2];
        }
        
    }

    public void Interact()
    {
        //spawn ghost tower
        if (isEmpty)
        {
            this.gameObject.GetComponent<Renderer>().material = Materials[1];
            GhostTurret[0].SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = Materials[1];
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if(isEmpty)
            {
                GhostTurret[0].SetActive(false);
                TurretTower.SetActive(true);
                isEmpty = false;
            }
            else if(!isEmpty)
            {
                Debug.Log("Turret Remove");
                TurretTower.SetActive(false);
                isEmpty = true;
            }
            
        }
    }
}
