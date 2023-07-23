using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayableObject
{
    [SerializeField] private Camera camera;
    [SerializeField] private float timeToDie;
    //[SerializeField] private float weaponDamage;
    //[SerializeField] private float weaponSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float playerHealth;

    private Rigidbody2D playerRigidBody;    
    private Health health;
    private string name;

    private float timerCooldown = 0;

    public Action<float> healthUpdate;
    public float speed;


    private void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        health = new Health(playerHealth, 0.5f, playerHealth);
        healthUpdate?.Invoke(health.GetHealth());

        //Set player weapon
        weapon = new Weapon();
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

    public override void Shoot(Vector3 direction, float rate)
    {
        if(timerCooldown == 0)
        {
            weapon.Shoot(bulletPrefab, this);
        }

        if (timerCooldown < rate)
        {
            timerCooldown += Time.deltaTime;
        }
        else
        {
            timerCooldown = 0;
        }

        
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        healthUpdate?.Invoke(health.GetHealth());

        if(health.GetHealth() <= 0)
        {
            StartCoroutine(Die());
        }
    }

    public void AddHealth()
    {
        health.AddHealth(5);
        healthUpdate?.Invoke(health.GetHealth());
    }
}
