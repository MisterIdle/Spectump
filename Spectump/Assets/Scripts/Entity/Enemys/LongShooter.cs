using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongShooter : EnemyManager
{
    public List<Transform> cannonsPosition = new List<Transform>();
    public GameObject bulletPrefab;

    public float fireRate = 0.5f;
    float nextFireTime = 0f;

    public float switchDistance = 10f;
    
    public LongShooter(int health, int mouvementSpeed, float rotationSpeed) : base(health, mouvementSpeed, rotationSpeed)
    {
    }
    
    public void Update()
    {
        if(PlayerIsNear())
        {
            FireBullet();
            Rotate();
        }
        else
        {
            Move();
            Rotate();
        }
    }


    private bool PlayerIsNear()
    {
        float distance = Vector3.Distance(GetPlayerPosition(), transform.position);
        
        if (distance <= switchDistance)
            return true;
        else
            return false;
    }

    private void FireBullet()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;

            foreach (Transform cannon in cannonsPosition)
            {
                Instantiate(bulletPrefab, cannon.position, cannon.rotation);
            }
        }
    }
}
