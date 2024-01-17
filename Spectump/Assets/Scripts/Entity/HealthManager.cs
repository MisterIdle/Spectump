using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 75;
    public float maxHealth = 100f;

    public Image healthBarImage;

    void Update()
    {
        healthBarImage.fillAmount = health / maxHealth;
    }
}
