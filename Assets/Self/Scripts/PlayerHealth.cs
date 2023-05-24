using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 5;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            diePlayer();
        }
    }

    private void diePlayer()
    {
        //Handle player death here, such as showing a game over screen, restarting the level, etc.
        //For now, disable the player object
        gameObject.SetActive(false);
        Debug.Log("Game Over");
    }

}
