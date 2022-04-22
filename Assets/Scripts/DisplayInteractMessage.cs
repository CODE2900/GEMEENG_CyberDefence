using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class DisplayInteractMessage : MonoBehaviour
{
    public TextMeshProUGUI MessageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMesssageText(string message)
    {
        Assert.IsNotNull(MessageText, "Message text is not set in UI");
        this.gameObject.SetActive(true);
        MessageText.text = message;
    }

    public void RemoveMessageText()
    {
        Assert.IsNotNull(MessageText, "Message text is not set in UI");
        MessageText.text = "";
        this.gameObject.SetActive(false);
    }
}
