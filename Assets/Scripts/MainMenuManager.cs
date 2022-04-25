using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private void Awake()
    {
        SingletonManager.Register(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnStartButtonClicked()
    {
        Debug.Log("Game Start");
        SceneManager.LoadScene(1);
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
