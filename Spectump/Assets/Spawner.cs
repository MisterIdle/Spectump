using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool isBlinking = false;

    public int kripsGroupMin = 2;
    public int kripsGroupMax = 5;
    private int kripsGroup;

    Canvas canvas;

    public List<GameObject> spawnMobType = new List<GameObject>();

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        kripsGroup = Random.Range(kripsGroupMin, kripsGroupMax);
        InvokeRepeating("SpawnKrips", 3, 0.5f);
        InvokeRepeating("ToggleBlink", 1, 0.3f);
    }

    private void ToggleBlink()
    {
        isBlinking = !isBlinking;
    }

    private void Update()
    {
        Clignotement();
    }

    private void Clignotement()
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

    private void SpawnKrips()
    {
        if (kripsGroup > 0)
        {
            Instantiate(spawnMobType[0], transform.position, Quaternion.identity);
            kripsGroup--;
        }
        else
        {
            CancelInvoke("SpawnKrips");
            CancelInvoke("ToggleBlink");
            Destroy(gameObject);
        }
    }
}
