using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f; // Enemy health
    private EnemySpawner enemySpawner; // Reference to the EnemySpawner

    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>(); // Find the EnemySpawner in the scene
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        enemySpawner.EnemyDefeated(); // Notify the spawner that the enemy is defeated
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}


