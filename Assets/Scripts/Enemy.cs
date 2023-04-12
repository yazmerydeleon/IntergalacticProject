using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    //Properties
    private string name;
    private float speed;
    private EnemyType enemyType;

    public Health health;
    public Weapon weapon;

    public void Move()
    {

    }

    public void Shoot()
    {

    }

    public void Attack()
    {

    }

    public void Die()
    {

    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }
}
