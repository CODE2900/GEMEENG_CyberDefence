using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    //public UnityEvent EvtInteracted = new UnityEvent();
    //[HideInInspector] public UnityEvent EvtInteracted = new UnityEvent();
    //public UnityEvent EvtInteracted { get; private set; } = new UnityEvent();
    /*public int Number { get; private set; 
        
    
    }*/
    public UnityEvent EvtInteracted = new UnityEvent();
    public UnityAction Interacted;

    public void Interact()
    {
        EvtInteracted.Invoke();
        Interacted.Invoke(); 
    }


}
