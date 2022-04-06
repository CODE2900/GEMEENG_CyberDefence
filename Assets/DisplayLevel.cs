using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class DisplayLevel : MonoBehaviour
{
    public Level Level;
    public TextMeshProUGUI LevelText;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(Level, "Level not set in LevelText");
        if (LevelText == null)
        {
            LevelText = this.GetComponent<TextMeshProUGUI>();
        }
        Level.OnLevelUp.AddListener(UpdateLevelText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateLevelText()
    {
        LevelText.text = "Level: " + Level.CurrentLevel.ToString("0");
    }
}
