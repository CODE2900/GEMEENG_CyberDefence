using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
public class WaveManager : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    public List<WaveData> waves = new List<WaveData>();
    public int waveCount = 0;
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
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWave()
    {
        if(waves.Count > 0)
        {
            if (waveCount < waves.Count)
            {
                if (spawners.Count > 0)
                {
                    OnStartWave.Invoke();
                    for (int i = 0; i < spawners.Count; i++)
                    {
                        Spawner spawner = spawners[i].GetComponent<Spawner>();
                        int randomEnemyToSpawnIndex = Random.Range(0, waves[waveCount].EnemiesToSpawn.Count);
                        if (spawner)
                        {
                            spawner.enemyPrefab = waves[waveCount].EnemiesToSpawn[randomEnemyToSpawnIndex];
                            spawner.numOfEnemiesToSpawn = waves[waveCount].NumToSpawn;
                            spawner.BeginSpawning();
                        }
                    }
                    waveCount++;
                    waveSpawningRoutine = StartCoroutine(WaveSpawning());
                }
            }
        }
    }

    IEnumerator WaveSpawning()
    {
        yield return new WaitForSeconds(SpawnTimer);
        StartWave();
    }
}
