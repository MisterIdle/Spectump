using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement playerManager = other.gameObject.GetComponent<PlayerMovement>();

            if (playerManager != null)
            {
                playerManager.SetDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
