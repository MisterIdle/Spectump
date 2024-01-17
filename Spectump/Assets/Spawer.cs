using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public CompositeCollider2D compositeCollider;

    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;

    private float spawnInterval;

    void Start()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        Bounds colliderBounds = compositeCollider.bounds;

        float randomX = Random.Range(colliderBounds.min.x, colliderBounds.max.x);
        float randomY = Random.Range(colliderBounds.min.y, colliderBounds.max.y);

        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Correction : Réinitialiser spawnInterval ici pour un nouvel intervalle aléatoire
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
