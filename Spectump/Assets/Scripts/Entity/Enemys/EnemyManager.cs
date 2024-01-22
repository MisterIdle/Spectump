using UnityEngine;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour 
{
    private Transform player;
    public SpriteRenderer sprite;

    public Vector3 direction;

    public int health = 0;
    public int speed = 0;

    public EnemyManager(int health, int speed)
    {
        this.health = health;
        this.speed = speed;
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
    { return player.position; }

    public void Rotate()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
