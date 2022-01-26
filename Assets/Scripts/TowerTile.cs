using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : MonoBehaviour
{
    public Interactable Interactable;

    // Start is called before the first frame update
    void Start()
    {
        Interactable.EvtInteracted.AddListener(OnInteracted);
        Interactable.EvtInteracted.RemoveListener(OnInteracted);
        Interactable.EvtInteracted.RemoveAllListeners();
        Interactable.Interacted += OnInteracted;
        Interactable.Interacted -= OnInteracted;
        
    }

    public void OnInteracted()
    {

    }

}
