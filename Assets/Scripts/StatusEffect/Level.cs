using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    public int CurrentLevel = 1;
    public int MaxLevel = 3;
    public TurretAttributes TurretStats;
    public TurretAttributes UpgradeTurretStats;
    public List<int> RequiredGold;

    [Header("Unity Events")]
    public UnityEvent OnLevelUp = new();
    public UnityEvent OnInsufficientGold = new();

    private Interactable interactable;
    

    private void Start()
    {
        TurretStats = this.GetComponent<TurretAttributes>();
        interactable = this.GetComponent<Interactable>();
        if (interactable)
        {
            interactable.EvtInteracted.AddListener(LevelUp);
        }
    }
    private void Interact()
    {

    }

    public void LevelUp(GameObject Player)
    {
        SingletonManager.Get<UIManager>().InteractUI.GetComponent<DisplayInteractMessage>().ChangeMesssageText("T To Upgrade");
        if (Input.GetKeyDown(KeyCode.T))
        {
            Gold playerGold = Player.GetComponent<Gold>();
            if (playerGold)
            {
                if(playerGold.CurrentGold >= RequiredGold[CurrentLevel-1])
                {
                    if (CurrentLevel < MaxLevel)
                    {
                        CurrentLevel++;
                        TurretStats.Damage += UpgradeTurretStats.Damage;
                        TurretStats.FireRate += UpgradeTurretStats.FireRate;
                        Debug.Log("Upgraded");
                        
                    }
                    playerGold.ReduceGold(RequiredGold[CurrentLevel-1]); 
                    OnLevelUp.Invoke();
                }
                else
                {
                    Debug.Log("Not enough Gold");
                    OnInsufficientGold.Invoke();
                }
            }
            
        }
        
    }

}
