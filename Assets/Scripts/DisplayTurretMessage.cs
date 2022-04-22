using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayTurretMessage : MonoBehaviour
{
    public Level Level;
    public TextMeshProUGUI MessageText;
    public float TextDuration = 2f;
    private Coroutine displayMessageRoutine;

    // Start is called before the first frame update
    void Start()
    {
        Level.OnInsufficientGold.AddListener(DisplayInsufficientGold);
        Level.OnLevelUp.AddListener(DisplayUpgradedMessage);
    }

    public void DisplayInsufficientGold()
    {
        displayMessageRoutine = StartCoroutine(DisplayMessageRoutine("Gold Insufficient"));
    }
    public void DisplayUpgradedMessage()
    {
        displayMessageRoutine = StartCoroutine(DisplayMessageRoutine("Upgraded"));
    }

    IEnumerator DisplayMessageRoutine(string message)
    {
        MessageText.text = message;
        yield return new WaitForSeconds(TextDuration);
        MessageText.text = "";
    }
}
