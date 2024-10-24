using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    public Transform player; // Reference to the player's Transform
    public float spawnDistance = 10f; // Distance in front of the player to spawn enemies

    private int enemiesToSpawn; // Track how many enemies to spawn
    private int enemiesDefeated = 0; // Track how many enemies have been defeated

    void Start()
    {
        StartCoroutine(GameLoop()); // Start the game loop
    }

    private IEnumerator GameLoop()
    {
        // Move the player for 2 seconds
        yield return player.GetComponent<PlayerMovement>().MoveForDuration(2f);

        // Spawn 2 enemies
        enemiesToSpawn = 2;
        yield return StartCoroutine(SpawnEnemies());

        // Wait until all enemies are defeated
        yield return new WaitUntil(() => enemiesDefeated == enemiesToSpawn);

        // Move the player for 2 seconds again
        yield return player.GetComponent<PlayerMovement>().MoveForDuration(2f);

        // Spawn 3 enemies
        enemiesToSpawn = 3;
        yield return StartCoroutine(SpawnEnemies());

        // Wait until all enemies are defeated
        yield return new WaitUntil(() => enemiesDefeated == enemiesToSpawn);
    }

    private IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // Calculate the spawn position in front of the player
            Vector3 spawnPosition = player.position + player.forward * spawnDistance;
            spawnPosition.y = 1.0f; // Adjust Y position above ground level

            // Spawn the enemy at the determined spawn position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(0.5f); // Wait before spawning the next enemy
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++; // Increment the count of defeated enemies
    }
}
