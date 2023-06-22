using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] float spawnRate = 2f;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject asteroidPrefab;

    private float gameplayTimer = 0f;
    private float timeSinceLastSpawn = 0f;
    private float asteroidMoveSpeedOverride = 2f;
    private float difficulityTimerThreshold = 5f;

    private void Update()
    {
        gameplayTimer += Time.deltaTime;
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
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
        asteroid.GetComponent<AsteroidController>().moveSpeed = asteroidMoveSpeedOverride;
        DifficulityManager();
    }

    private void DifficulityManager()
    {
        
        if(gameplayTimer >= difficulityTimerThreshold)
        {
            asteroidMoveSpeedOverride += 1f;
            difficulityTimerThreshold += 5f; 
        }
    }
}
