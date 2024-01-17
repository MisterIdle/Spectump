using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;

    private Transform player;
    public GameObject sprite;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();
            transform.Translate(direction * speed * Time.deltaTime);

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        }
    }
}
