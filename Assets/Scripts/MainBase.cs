using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainBase : Unit
{
    public Interactable Interactable;

    // Start is called before the first frame update
    void Start()
    {
        if (Interactable != null)
        {
            Interactable.EvtInteracted.AddListener(Interact);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<Health>().Heal(10.0f);
        }
    }
}
