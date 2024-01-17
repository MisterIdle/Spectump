using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 2f;
    private float invincibilityDuration = 1f;

    public GameObject bulletPrefab;
    public SpriteRenderer playerSprite;
    public Transform firePoint;

    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    private bool isInvincible = false;
    private float invincibilityEndTime = 0f;

    private float blinkTimer = 0f;
    private bool isVisible = true;

    private HealthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        Clignotement();
        RotatePlayer();
        MovePlayer();
        Life();

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

    void RotatePlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void FireBullet()
    {
        nextFireTime = Time.time + 1f / fireRate;
        Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    }

    void Life()
    {
        if (healthManager.health == 0)
        {
            Destroy(gameObject);
        }
    }

    void Clignotement()
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

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            healthManager.health -= damage;
            isInvincible = true;
            invincibilityEndTime = Time.time + invincibilityDuration;
            Clignotement();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isInvincible)
        {
            TakeDamage(1);

            Destroy(collision.gameObject);
        }
    }
}
