using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField]
    Transform spawnPoint; 
    public List<GameObject> waypoints = new List<GameObject>();
    public int numOfEnemiesToSpawn = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemies()
    {
        if(numOfEnemiesToSpawn > 0)
        {
            for (int i = 0; i < numOfEnemiesToSpawn; i++)
            {
                Assert.IsNotNull(enemyPrefab, "Enemy prefab should not be null or empty");
                GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            }
            
        }
    }

}
