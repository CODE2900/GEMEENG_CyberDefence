using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int turretInventory = 4;
    
    //Turrets 
    public List<GameObject> Turrets;
    public List<int> TurretCount;

    public UnityEvent OnUseInventory = new();
    // Start is called before the first frame update
    public void Awake()
    {
        
    }
    void Start()
    {
        SingletonManager.Register(this);
    }

}
