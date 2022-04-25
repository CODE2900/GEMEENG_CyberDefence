using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class DisplayTotalKills : MonoBehaviour
{
    public GameManager GameManager;
    public TextMeshProUGUI TotalKillCountText;

    private void Awake()
    {
        if(GameManager == null)
        {
            GameManager = SingletonManager.Get<GameManager>();
        }
        GameManager.OnGameEnd.AddListener(ShowTotalKills);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void ShowTotalKills()
    {
        Assert.IsNotNull(TotalKillCountText, "Total kill count text not set");
        TotalKillCountText.text = GameManager.TotalEnemyKilled.ToString();
    }
}
