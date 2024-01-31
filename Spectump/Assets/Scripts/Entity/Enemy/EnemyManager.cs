using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour 
{
    [Header("Player")]
    private Transform player;

    [Header("Sprite")]
    public SpriteRenderer sprite;

    [Header("Movement")]
    public int health = 0;
    public int mouvementSpeed = 0;
    public float rotationSpeed = 0;

    [Header("Attack")]
    public bool canAttack = false;
    public List<Transform> cannonList = new List<Transform>();
    public GameObject bulletPrefab;

    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    public EnemyManager(int health, int mouvementSpeed, float rotationSpeed)
    {
        this.health = health;
        this.mouvementSpeed = mouvementSpeed;
        this.rotationSpeed = rotationSpeed;
    }

    public void Awake()
    {
        GameObject lPlayerPosition = GameObject.FindGameObjectWithTag("Player");
        if (lPlayerPosition != null)
        {
            player = lPlayerPosition.transform;
        }
    }

    public Vector3 GetPlayerPosition()
    {
        if (player != null)
        {
            return player.transform.position;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public virtual void Move()
    {
        Vector3 movement = sprite.transform.up;
        transform.position += movement * mouvementSpeed * Time.deltaTime;
    }

    public void Rotate()
    {
        sprite.transform.rotation = Quaternion.Slerp(sprite.transform.rotation, Quaternion.LookRotation(Vector3.forward, GetPlayerPosition() - transform.position), rotationSpeed * Time.deltaTime);
    }

    public void Shoot() {
        if (canAttack && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (Transform cannon in cannonList)
            {
                Instantiate(bulletPrefab, cannon.position, cannon.rotation);
            }
        }
    }

    public void SetDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
