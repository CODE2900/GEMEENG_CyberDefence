using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class DisplayInventory : MonoBehaviour
{
    public Inventory Inventory;
    public TextMeshProUGUI InventoryText; 
    // Start is called before the first frame update
    void Start()
    {
        if(Inventory == null)
        {
            Inventory = SingletonManager.Get<GameManager>().Player.GetComponent<Inventory>();
        }
        Assert.IsNotNull(Inventory, "No Inventory in Display Inventory");
        Inventory.OnUseInventory.AddListener(UpdateInventoryText);
        Assert.IsNotNull(InventoryText, "No InventoryText in Display Inventory");

    }

    void UpdateInventoryText()
    {
        InventoryText.text = Inventory.turretInventory.ToString("0");
    }
}
