using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MobType
{
    Krip,
    LongShooter
}

public class Spawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public bool kripCanSpawn = true;
    public bool longShooterCanSpawn = true;

    [Header("Krip Settings")]
    public int kripsGroupMin = 2;
    public int kripsGroupMax = 5;
    
    [Header("Spawn Mob Type")]
    public List<GameObject> spawnMobType = new List<GameObject>();

    [Header("Spawn Pourcentage")]
    public float kripSpawnPourcentage = 0.6f;
    public float longShooterSpawnPourcentage = 0.4f;

    int kripsGroup;
    int longShooterGroup = 1;
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
        if (kripCanSpawn && kripsGroup > 0 && spawnRandom == 0)
        {
            Instantiate(spawnMobType[(int)MobType.Krip], transform.position, Quaternion.identity);
            kripsGroup--;

            if (kripsGroup == 0)
            {
                CancelInvoke("SpawnMobs");
                CancelInvoke("ToggleBlink");
                Destroy(gameObject);
            }
        }

        if (longShooterCanSpawn && longShooterGroup > 0 && spawnRandom == 1)
        {
            Instantiate(spawnMobType[(int)MobType.LongShooter], transform.position, Quaternion.identity);
            longShooterGroup--;

            if (longShooterGroup == 0)
            {
                CancelInvoke("SpawnMobs");
                CancelInvoke("ToggleBlink");
                Destroy(gameObject);
            }
        }
    }
}
