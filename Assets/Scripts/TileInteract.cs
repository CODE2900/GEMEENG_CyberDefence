using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileInteract : MonoBehaviour
{
    public UnityEvent InteractedTile = new UnityEvent();
    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        InteractedTile.AddListener(tileInteract);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        this.gameObject.GetComponent<Renderer>().material = materials[0];
    }

    public void tileInteract()
    {
        this.gameObject.GetComponent<Renderer>().material = materials[1];
    }

}
