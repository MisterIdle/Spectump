using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 2f;
    public float rotationSpeed = 5f;

    [Header("Health")]
    public float health = 75;

    [Header("Shooting")]
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    [Header("Components")]
    public List<Transform> bulletSpawnPoints = new List<Transform>();
    public GameObject bulletPrefab;
    public SpriteRenderer playerSprite;
    public Transform firePoint;


    public bool isInvincible = false;
    private float invincibilityEndTime = 0f;

    private float blinkTimer = 0f;
    private bool isVisible = true;

    void Update()
    {
        Move();
        Rotation();
        Blinking();

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            FireBullet();
        }

        if (isInvincible && Time.time >= invincibilityEndTime)
        {
            isInvincible = false;
            playerSprite.enabled = true;
        }
    }

    void Move() 
    {
        Vector3 movement = playerSprite.transform.up;
        transform.position += movement * movementSpeed * Time.deltaTime;
    }

    void Rotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerSprite.transform.rotation = Quaternion.Slerp(playerSprite.transform.rotation, Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position), rotationSpeed * Time.deltaTime);
    }

    void FireBullet()
    {
        nextFireTime = Time.time + 1f / fireRate;
        Shoot();
    }

    void Shoot() {
        foreach (Transform bulletSpawnPoint in bulletSpawnPoints)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
    }

    void Blinking()
    {
        if (isInvincible)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer >= 0.1f)
            {
                isVisible = !isVisible;
                playerSprite.enabled = isVisible;
                blinkTimer = 0f;
            }
        }
    }

    public void SetDamage(float damageAmount)
    {
        if (!isInvincible)
        {
            health -= damageAmount;
            Debug.Log(health);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                isInvincible = true;
                invincibilityEndTime = Time.time + 2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isInvincible)
        {
            Destroy(collision.gameObject);
            SetDamage(50);
        }
    }
}
