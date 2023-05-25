using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameWinScreen;
    public GameObject restartButton;

    private EnemySpawner enemySpawner;
    private PlayerHealth playerHealth;

    private bool isGameOver = false;
    private bool isGameWon = false;

    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        playerHealth = FindObjectOfType<PlayerHealth>();

        // Subscribe to events
        playerHealth.OnPlayerDeath += GameOver;
        enemySpawner.OnEnemyDefeated += CheckWinCondition;
    }

    private void Update()
    {
        if ((isGameOver || isGameWon) && Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        restartButton.SetActive(true);
        isGameOver = true;
    }

    private void CheckWinCondition()
    {
        if (enemySpawner.GetCurrentEnemyCount() <= 0)
        {
            gameWinScreen.SetActive(true);
            restartButton.SetActive(true);
            isGameWon = true;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
