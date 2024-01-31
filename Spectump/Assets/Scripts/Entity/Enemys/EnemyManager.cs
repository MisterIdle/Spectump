using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour 
{
    private Transform player;
    public SpriteRenderer sprite;

    public Vector3 direction;

    public int health = 0;
    public int mouvementSpeed = 0;
    public float rotationSpeed = 0;

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

    public void Move()
    {
        Vector3 movement = sprite.transform.up;
        transform.position += movement * mouvementSpeed * Time.deltaTime;
    }

    public void Rotate()
    {
        sprite.transform.rotation = Quaternion.Slerp(sprite.transform.rotation, Quaternion.LookRotation(Vector3.forward, GetPlayerPosition() - transform.position), rotationSpeed * Time.deltaTime);
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
