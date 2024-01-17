using UnityEngine;

public class KripsScript : MonoBehaviour
{
    public float speed = 5f;

    private Transform player;
    public GameObject sprite;

    private Vector2 direction;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            Move();
            Rotate();
        }
    }

    void Move()
    {
        if (player != null)
        {
            direction = player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (player != null)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
}
