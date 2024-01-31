using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperSpawner : MonoBehaviour
{
    public GameObject spawner;
    public CompositeCollider2D compositeCollider;

    public float spawnIntervalMin = 5;
    public float spawnIntervalMax = 5;
    private float spawnInterval;

    public bool crossCanSpawn = true;

    void Start()
    {
        if (crossCanSpawn)
        {
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            InvokeRepeating("SpawnCross", 0f, spawnInterval);
        }
    }

    void SpawnCross()
    {
        Bounds colliderBounds = compositeCollider.bounds;

        float randomX = Random.Range(colliderBounds.min.x, colliderBounds.max.x);
        float randomY = Random.Range(colliderBounds.min.y, colliderBounds.max.y);

        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(spawner, spawnPosition, Quaternion.identity);
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
