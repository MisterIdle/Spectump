using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;

    public GameObject explosion;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyManager enemyManager = other.gameObject.GetComponent<EnemyManager>();
            Instantiate(explosion, transform.position, transform.rotation);

            if (enemyManager != null)
            {
                enemyManager.SetDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
