using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    public Canvas PlayerCanvas;
    public GameObject InteractUI;

    private void Awake()
    {
        SingletonManager.Register(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnRetryButtonClicked()
    {
        SingletonManager.Remove<GameManager>();
        SingletonManager.Remove<UIManager>();
        SingletonManager.Remove<WaveManager>();
        SingletonManager.Remove<AudioManager>();
        SingletonManager.Remove<Inventory>();
        SceneManager.LoadScene("MapScene_Navigation");
        Debug.Log("Reloading Map");
    }

    public void OnBackToMenuButtonClicked()
    {
        SingletonManager.Remove<GameManager>();
        SingletonManager.Remove<UIManager>();
        SingletonManager.Remove<WaveManager>();
        SingletonManager.Remove<AudioManager>();
        SingletonManager.Remove<MainMenuManager>();
        SingletonManager.Remove<Inventory>();
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Back to Main Menu");
    }

    


}
