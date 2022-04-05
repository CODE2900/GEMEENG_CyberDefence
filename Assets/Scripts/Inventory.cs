using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int turretInventory = 4;
    
    //Turrets 
    public List<GameObject> Turrets;
    public List<int> TurretCount;
    // Start is called before the first frame update
    public void Awake()
    {
        
    }
    void Start()
    {
        SingletonManager.Register(this);
    }

}
