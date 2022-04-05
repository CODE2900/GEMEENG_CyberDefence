using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretCount : MonoBehaviour
{
    public GameObject Player;
    private Inventory playerInventory;

    [Header("UI")]
    public TextMeshProUGUI turretCount;

    void Start()
    {
        if(Player.gameObject.GetComponent<Inventory>() != null)
        {
            playerInventory = Player.gameObject.GetComponent<Inventory>();
        }
    }

    // Update is called once per frame
    void Update()
    {
       // turretCount.text = "Basic Turret: " + playerInventory.Turrets.Count;
    }
}
