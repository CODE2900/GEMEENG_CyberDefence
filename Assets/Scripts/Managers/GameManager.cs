using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void GameWon()
    {
        GameWonUI.SetActive(true);
    }
}
