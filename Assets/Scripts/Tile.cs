using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material[] Materials;

    public Interactable Interactable;

    public GameObject[] GhostTurret;
    public int GhostTurretIndex;
    public GameObject TurretTower;
    public GameObject EMPTower;

    bool isEmpty = true;

    // Start is called before the first frame update
    void Start()
    {
        GhostTurretIndex = 0;
        if (Interactable != null)
        {
            Interactable.EvtInteracted.AddListener(Interact);
        }

    }

    public void FixedUpdate()
    {
        if (isEmpty)
        {
            this.gameObject.GetComponent<Renderer>().material = Materials[0];
            GhostTurret[0].SetActive(false);
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material = Materials[2];
        }

    }

    public void Interact(GameObject Player)
    {
        SingletonManager.Get<UIManager>().InteractUI.GetComponent<DisplayInteractMessage>().ChangeMesssageText("Q to change turret. E to place turret");
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(GhostTurretIndex > GhostTurret.Length)
            {
                GhostTurretIndex = 0;
            }
            else
            {
                GhostTurretIndex++;
            }
        }

        if(SingletonManager.Get<Inventory>().turretInventory > 0)
        {
            //spawn ghost tower
            if (isEmpty && GhostTurretIndex == 0)
            {
                this.gameObject.GetComponent<Renderer>().material = Materials[1];
                GhostTurret[0].SetActive(true);
                GhostTurret[1].SetActive(false);
            }
            else if (isEmpty && GhostTurretIndex == 1)
            {
                this.gameObject.GetComponent<Renderer>().material = Materials[1];
                GhostTurret[0].SetActive(false);
                GhostTurret[1].SetActive(true);
            }
            else
            {
                this.gameObject.GetComponent<Renderer>().material = Materials[0];
            }


            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isEmpty && GhostTurretIndex == 0)
                {
                    SingletonManager.Get<Inventory>().turretInventory -= 1;
                    GhostTurret[0].SetActive(false);
                    TurretTower.SetActive(true);
                    TurretTower.GetComponent<Turret>().Targeting.targets.Clear();
                    isEmpty = false;
                }
                else if (isEmpty && GhostTurretIndex == 1)
                {
                    SingletonManager.Get<Inventory>().turretInventory -= 1;
                    GhostTurret[1].SetActive(false);
                    EMPTower.SetActive(true);
                    EMPTower.GetComponent<Turret>().Targeting.targets.Clear();
                    isEmpty = false;
                }
                else if (!isEmpty)
                {
                    SingletonManager.Get<Inventory>().turretInventory += 1;
                    Debug.Log("Turret Remove");
                    if (TurretTower.activeInHierarchy)
                    {
                        TurretTower.SetActive(false);
                        TurretTower.GetComponent<Turret>().Targeting.targets.Clear();
                        isEmpty = true;
                    }
                    else if (EMPTower.activeInHierarchy)
                    {
                        EMPTower.SetActive(false);
                        EMPTower.GetComponent<Turret>().Targeting.targets.Clear();
                        isEmpty = true;
                    }

                }

            }
        }
        
    }
}
