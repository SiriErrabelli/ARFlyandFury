using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [Header("Balloon Settings")]
    public GameObject balloonPrefab; // Reference to the balloon prefab
    public float spawnInterval = 2f; // Time between spawns
    public float spawnRadius = 2f;  // Radius around the AR space to spawn balloons
    public float minSpawnHeight = 0.5f; // Minimum height for spawning balloons
    public float maxSpawnHeight = 2.5f; // Maximum height for spawning balloons

    private bool spawnBalloons = true;

    private void Start()
    {
        // Start the balloon spawning loop
        StartCoroutine(SpawnBalloons());
    }

    private IEnumerator SpawnBalloons()
    {
        while (spawnBalloons)
        {
            SpawnBalloon();
            yield return new WaitForSeconds(spawnInterval); // Wait for the next spawn
        }
    }

    private void SpawnBalloon()
    {
        // Generate a random position within the spawn radius
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(minSpawnHeight, maxSpawnHeight),
            Random.Range(-spawnRadius, spawnRadius)
        );

        // Instantiate the balloon prefab at the random position
        Instantiate(balloonPrefab, randomPosition, Quaternion.identity, transform);
    }
}
