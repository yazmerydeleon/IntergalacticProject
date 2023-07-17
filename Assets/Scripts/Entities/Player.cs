using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    [SerializeField] private Camera camera;
    [SerializeField] private float timeToDie;
    [SerializeField] private float weaponDamage;
    [SerializeField] private float weaponSpeed;
    [SerializeField] private GameObject bulletPrefab;

    private Rigidbody2D playerRigidBody;    
    private Health health;
    private string name;

    public Action<float> healthUpdate;
    public float speed;


    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        health = new Health(100, 0.5f, 50);
        healthUpdate?.Invoke(health.GetHealth());

        //Set player weapon
        weapon = new Weapon("Player Weapon", weaponDamage, weaponSpeed);
    }
        
    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRigidBody.velocity = direction * speed * Time.deltaTime;

        Vector3 playerScreenPosition = camera.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    public override void Shoot(Vector3 direction, float speed)
    {
        weapon.Shoot(bulletPrefab, this, "Enemy", timeToDie);
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        healthUpdate?.Invoke(health.GetHealth());

        if(health.GetHealth() <= 0)
        {
            Die();
        }
    }

    public void AddHealth()
    {
        health.AddHealth(5);
        healthUpdate?.Invoke(health.GetHealth());
    }
}
