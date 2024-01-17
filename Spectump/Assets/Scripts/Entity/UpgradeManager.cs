using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Sprite> tier = new List<Sprite>(9);
    public SpriteRenderer spriteRenderer;
    public float spriteID = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            IncrementSpriteID();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            DecrementSpriteID();
        }

        spriteID = Mathf.Clamp(spriteID, 0, tier.Count - 1);
        spriteRenderer.sprite = tier[(int)spriteID];
    }

    void IncrementSpriteID()
    {
        spriteID++;
    }

    void DecrementSpriteID()
    {
        spriteID--;
    }
}
