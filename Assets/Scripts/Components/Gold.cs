using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gold : MonoBehaviour
{
    public int CurrentGold;
    public int StartingGold;
    public int GoldReward;
    public UnityEvent OnGoldChange = new();
    private Health unitHealth;

 

    // Start is called before the first frame update
    void Start()
    {
        CurrentGold = StartingGold;
        OnGoldChange.Invoke();
        unitHealth = GetComponent<Health>();
        if (unitHealth)
        {
            unitHealth.OnDeath.AddListener(RewardDeath);
        }
    }

    public void ReduceGold(int cost)
    {
        CurrentGold -= cost;
        OnGoldChange.Invoke();
    }

    public void AddGold(int gold)
    {
        CurrentGold += gold;
        OnGoldChange.Invoke();
    }

    public void RewardDeath()
    {
        Gold attackerGold = unitHealth.Attacker.GetComponent<Gold>();
        if (attackerGold)
        {
            attackerGold.AddGold(GoldReward);
            OnGoldChange.Invoke();
        }
    }
}
