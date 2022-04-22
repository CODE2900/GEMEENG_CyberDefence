using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions;

public class DisplayGold : MonoBehaviour
{
    public Gold PlayerGold;
    public TextMeshProUGUI GoldCounterText;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void UpdateGoldCounter()
    {
        GoldCounterText.text = PlayerGold.CurrentGold.ToString("0");
    }

    void Initialize()
    {
        if (PlayerGold == null)
        {
            PlayerGold = SingletonManager.Get<GameManager>().Player.GetComponent<Gold>();
        }
        Assert.IsNotNull(PlayerGold, "Player Gold is not set in UI");
        Assert.IsNotNull(GoldCounterText, "Gold Counter Text is not set in UI");
        PlayerGold.OnGoldChange.AddListener(UpdateGoldCounter);
        UpdateGoldCounter();
    }
}
