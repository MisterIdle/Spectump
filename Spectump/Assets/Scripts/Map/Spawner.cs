using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KripType
{
    KripT1,
    KripT2,
    KripT3,
}

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public bool kripCanSpawn = true;

    [Header("Krip Settings")]
    public int kripsGroupMin = 1;
    public int kripsGroupMax = 3;
    
    [Header("Spawn Mob Type")]
    public List<GameObject> spawnMobType = new List<GameObject>();

    [Header("Spawn Pourcentage")]
    public float kripSpawnPourcentage = 0.6f;
    public float longShooterSpawnPourcentage = 0.4f;

    int kripsGroup;
    int spawnRandom;

    SpriteRenderer spriteRenderer;
    bool isBlinking = false;

    public void Start()
    {
        float spawnProbability = Random.value;
    
        if (spawnProbability <= kripSpawnPourcentage)
        {
            spawnRandom = 0;
        }
        else if (spawnProbability <= longShooterSpawnPourcentage)
        {
            spawnRandom = 1;
        }
    
        spriteRenderer = GetComponent<SpriteRenderer>();
        kripsGroup = Random.Range(kripsGroupMin, kripsGroupMax);
        spawnRandom = Random.Range(0, spawnMobType.Count);
    
        InvokeRepeating("SpawnMobs", 3, 0.5f);
        InvokeRepeating("ToggleBlink", 1, 0.3f);
    }


    private void ToggleBlink()
    {
        isBlinking = !isBlinking;
    }

    private void Update()
    {
        CrossBlinking();
    }

    private void CrossBlinking()
    {
        if (isBlinking)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }

    private void SpawnMobs()
    {
        if (kripCanSpawn)
        {
            for (int i = 0; i < kripsGroup; i++)
            {
                GameObject krip = Instantiate(spawnMobType[spawnRandom], transform.position, transform.rotation);
            }
        }
    }
}
