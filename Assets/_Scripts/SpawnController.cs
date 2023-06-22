using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject asteroidPrefab;

    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            SpawnAsteroid();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnAsteroid()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
    }
}
