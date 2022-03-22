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
    public UnityEvent<GameObject> EvtInteractedGameObject = new();
    //public UnityAction Interacted;

    public void InvokeInteract()
    {
        EvtInteracted.Invoke();
        //Interacted.Invoke(); 
    }
    public void InvokeInteract(GameObject Player)
    {
        EvtInteractedGameObject.Invoke(Player);
    }

}
