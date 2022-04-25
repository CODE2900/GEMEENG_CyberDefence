using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class WaveManager : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    public List<WaveData> waves = new List<WaveData>();
    public int waveCount = 0;

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
            if(spawners.Count > 0)
            {
                for(int i = 0; i < spawners.Count; i++)
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
            }
        }
    }
}
