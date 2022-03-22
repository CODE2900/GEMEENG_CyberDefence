using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int CurrentGold;
    public int StartingGold;
    public int GoldReward;

    private Health unitHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentGold = StartingGold;
        unitHealth = GetComponent<Health>();
        if (unitHealth)
        {
            unitHealth.OnDeath.AddListener(RewardDeath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReduceGold(int cost)
    {
        CurrentGold -= cost;
    }

    public void AddGold(int gold)
    {
        CurrentGold += gold;
    }

    public void RewardDeath()
    {
        Gold attackerGold = unitHealth.Attacker.GetComponent<Gold>();
        if (attackerGold)
        {
            attackerGold.AddGold(GoldReward);
        }
    }
}
