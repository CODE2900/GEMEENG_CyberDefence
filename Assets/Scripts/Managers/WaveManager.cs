using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
public class WaveManager : MonoBehaviour
{
    public List<GameObject> Spawners = new List<GameObject>();
    public List<WaveData> Waves = new List<WaveData>();
    public int WaveCount = 0;
    public int TotalEnemyToSpawn = 0;
    public float SpawnTimer;
    public UnityEvent OnStartWave = new();
    private Coroutine waveSpawningRoutine;
    

    private void Awake()
    {
        SingletonManager.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalEnemyToSpawn = GetTotalEnemyCount();
        StartWave();
    }

    public void StartWave()
    {
        if(Waves.Count > 0)
        {
            if (WaveCount < Waves.Count)
            {
                if (Spawners.Count > 0)
                {
                    OnStartWave.Invoke();
                    for (int i = 0; i < Spawners.Count; i++)
                    {
                        Spawner spawner = Spawners[i].GetComponent<Spawner>();
                        int randomEnemyToSpawnIndex = Random.Range(0, Waves[WaveCount].EnemiesToSpawn.Count);
                        if (spawner)
                        {
                            spawner.enemyPrefab = Waves[WaveCount].EnemiesToSpawn[randomEnemyToSpawnIndex];
                            spawner.numOfEnemiesToSpawn = Waves[WaveCount].NumToSpawn;
                            spawner.BeginSpawning();
                        }
                    }
                    //waveCount++;
                    waveSpawningRoutine = StartCoroutine(WaveSpawning());
                }
            }
        }
    }

    IEnumerator WaveSpawning()
    {
        yield return new WaitForSeconds(SpawnTimer);
        if(WaveCount < Waves.Count)
        {
            WaveCount++;
            StartWave();
        }
        
    }

    private int GetTotalEnemyCount()
    {
        int totalEnemyCount = 0;
        for(int i = 0; i<Waves.Count; i++)
        {
            totalEnemyCount += Waves[i].NumToSpawn* Spawners.Count;
             Debug.Log("TotalEnemyCount: " + totalEnemyCount);
        }
        return totalEnemyCount;
    }

    public void CheckForEnemies()
    {
        //Debug.Log("TotalEnemyCount: " + totalEnemyCount);
        if(SingletonManager.Get<GameManager>().EnemyKilled >= TotalEnemyToSpawn)
        {
            SingletonManager.Get<GameManager>().GameWon();
        }
    }
}
