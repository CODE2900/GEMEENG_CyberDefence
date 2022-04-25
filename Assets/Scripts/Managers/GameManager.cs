using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainBase;
    public Transform playerCamera;
    public bool IsGameOver;

    [Header("Scoring")]
    public int EnemyKilled = 0;
    public int TotalEnemyKilled = 0;

    [Header("Game Over UI")]
    public GameObject GameEndUI;
    public GameObject GameWonUI;

    [Header("Events")]
    public UnityEvent OnGameEnd = new UnityEvent();

    private void Awake()
    {
        SingletonManager.Register(this);
       
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        GameEndUI.SetActive(false);
        GameWonUI.SetActive(false); 
        MainBase.GetComponent<Health>().OnDeath.AddListener(GameOver);
        IsGameOver = false;
    }

    void GameOver()
    {
        GameEndUI.SetActive(true);
        IsGameOver = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        TotalEnemyKilled += EnemyKilled;
        OnGameEnd.Invoke();
        
    }

    public void GameWon()
    {
        GameWonUI.SetActive(true);
        IsGameOver = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        TotalEnemyKilled += EnemyKilled;
        OnGameEnd.Invoke();
    }
}
