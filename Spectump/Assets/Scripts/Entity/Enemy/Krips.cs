using UnityEngine;

public class Krips : EnemyManager
{
    public Krips(int health, int mouvementSpeed, float rotationSpeed) : base(health, mouvementSpeed, rotationSpeed) { }

    private void Update() {
        Move();
        Rotate();
        Shoot();
    }
    
}
