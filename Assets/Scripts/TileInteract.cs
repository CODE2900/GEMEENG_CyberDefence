using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileInteract : MonoBehaviour // Rename to "Tile" class 
{
    //public UnityEvent InteractedTile = new UnityEvent();
    public Material[] Materials;
    public Interactable Interactable;
    // Start is called before the first frame update
    void Start()
    {
        Interactable.EvtInteracted.AddListener(Interact);
       //
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        this.gameObject.GetComponent<Renderer>().material = Materials[0];
    }

    public void Interact()
    {
        this.gameObject.GetComponent<Renderer>().material = Materials[1];
    }

}
