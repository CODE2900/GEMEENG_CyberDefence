using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBase : MonoBehaviour
{
    public Health Health;
    public Interactable Interactable;
    public int Cost = 500;
    public float HealAmount;
    // Start is called before the first frame update
    void Start()
    {
        Health = this.GetComponent<Health>();
        Interactable = this.GetComponent<Interactable>();
        if (Interactable)
        {
            Interactable.EvtInteracted.AddListener(HealBaseHP);
        }
    }

    public void HealBaseHP(GameObject Player)
    {
        SingletonManager.Get<UIManager>().InteractUI.GetComponent<DisplayInteractMessage>().ChangeMesssageText("E to Heal Base");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Gold playerGold = Player.GetComponent<Gold>();
            if (playerGold)
            {
                if (playerGold.CurrentGold >= Cost)
                {
                    Health.Heal(HealAmount);
                    playerGold.ReduceGold(Cost);
                    Debug.Log("Heal");
                }
                else
                {
                    Debug.Log("Insufficient Gold");
                }
            }
        }
        
    }

}
