using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainBase;
    public Transform playerCamera;

    [Header("Scoring")]
    public int EnemyKilled;
    public int TotalEnemyKilled;

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
        GameEndUI.SetActive(false);
        GameWonUI.SetActive(false); ;
        MainBase.GetComponent<Health>().OnDeath.AddListener(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        GameEndUI.SetActive(true);
        OnGameEnd.Invoke();
    }

    public void GameWon()
    {
        GameWonUI.SetActive(true);
        OnGameEnd.Invoke();
    }
}
