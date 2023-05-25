using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public delegate void EnemyDefeatedAction();


public class EnemySpawner : MonoBehaviour
{
    public event EnemyDefeatedAction OnEnemyDefeated;

    public int GetCurrentEnemyCount()
    {
        return currentEnemyCount;
    }
    public GameObject[] enemyPrefabs; //array of enemy prefabs
    public Transform spawnPoint;
    public float spawnDelay = 3f;
    public int maxEnemyCount = 10;

    private int currentEnemyCount = 0;
    private bool canSpawn = true;

    private void Start()
    {
        //Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    private System.Collections.IEnumerator SpawnEnemies()
    {
        while (canSpawn && currentEnemyCount < maxEnemyCount)
        {
            SpawnEnemy();
            currentEnemyCount++;

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject randomEnemyPrefab = enemyPrefabs[randomIndex];
        
        Instantiate(randomEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }

}
