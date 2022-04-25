using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    [SerializeField]
    Transform spawnPoint;
    public Transform Destination;
    public int numOfEnemiesToSpawn;

    public Coroutine spawnEnemiesRoutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnEnemies()
    {
        //if(numOfEnemiesToSpawn > 0)
        //{
           // for (int i = 0; i < numOfEnemiesToSpawn; i++)
            //{
                Assert.IsNotNull(enemyPrefab, "Enemy prefab should not be null or empty");
                GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                //spawnedEnemy.GetComponent<AIMovement>().waypoints = waypoints;
                spawnedEnemy.GetComponent<NavMeshAI>().waypoint = Destination;
        //}

        //}
    }

    public void BeginSpawning()
    {
        spawnEnemiesRoutine = StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        yield return null;
        for(int i = 0; i < numOfEnemiesToSpawn; i++)
        {
            yield return new WaitForSeconds(1.5f);
            SpawnEnemies();
        }
    }

}
