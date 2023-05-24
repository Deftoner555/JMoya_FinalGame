using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
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
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }

}
