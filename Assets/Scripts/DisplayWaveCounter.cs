using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Assertions;

public class DisplayWaveCounter : MonoBehaviour
{
    public WaveManager WaveManager;
    public TextMeshProUGUI CurrentWaveText;
    public TextMeshProUGUI MaxWaveText;

    // Start is called before the first frame update
    void Start()
    {
        WaveManager = SingletonManager.Get<WaveManager>();
        Assert.IsNotNull(WaveManager, "Wave manager is not set or empty");
        Assert.IsNotNull(CurrentWaveText, "CurrentWaveText is not set");
        Assert.IsNotNull(MaxWaveText, "MaxWaveText is not set");
        WaveManager.OnStartWave.AddListener(UpdateCurrentWaveText);
        UpdateCurrentWaveText();
        SetMaxWaveText();
    }

    public void UpdateCurrentWaveText()
    {
        CurrentWaveText.text = (WaveManager.WaveCount+1).ToString("0");
    }

    public void SetMaxWaveText()
    {
        MaxWaveText.text = WaveManager.Waves.Count.ToString();
    }
   
}
