using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperSpawner : MonoBehaviour
{
    public GameObject cross;
    public CompositeCollider2D compositeCollider;

    public float spawnIntervalMin = 1;
    public float spawnIntervalMax = 5;
    private float spawnInterval;

    void Start()
    {
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
        InvokeRepeating("SpawnCross", 0f, spawnInterval);
    }

    void SpawnCross()
    {
        Bounds colliderBounds = compositeCollider.bounds;

        float randomX = Random.Range(colliderBounds.min.x, colliderBounds.max.x);
        float randomY = Random.Range(colliderBounds.min.y, colliderBounds.max.y);

        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(cross, spawnPosition, Quaternion.identity);
        spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
