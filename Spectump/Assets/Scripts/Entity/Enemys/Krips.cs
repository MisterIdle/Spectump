using UnityEngine;

public class Krips : EnemyManager
{
    public Krips(int health, int speed) : base(health, speed) { }

    void Update()
    {
        move();
        Rotate();
    }

    void move()
    {
        direction = GetPlayerPosition() - transform.position;
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
