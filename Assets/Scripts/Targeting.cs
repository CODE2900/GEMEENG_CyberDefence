using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    [Header("Enemy Targeting")]
    [SerializeField]
    GameObject target;
    public GameObject Target { get { return target; } set { target = value; } }
    public List <GameObject> targets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
