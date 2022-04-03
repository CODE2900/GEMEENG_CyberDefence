using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int turretInventory = 4;
    public void Awake()
    {
        SingletonManager.Register(this);
    }

}
