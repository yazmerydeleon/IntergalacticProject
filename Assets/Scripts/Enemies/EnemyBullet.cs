using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private int damageToPlayer = 0;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDuration = 1f;
    private float bulletTime = 0;
    private Player player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform.GetComponent<Player>();
    }

    private void Update()
    {
        Move();
        bulletTime += Time.deltaTime;
        if(bulletTime > bulletDuration)
        {
            Destroy(gameObject);
        }

    }

    void Move()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       // Debug.Log("OnTriggerEnter2D:" + other);
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null && other.tag == "Player")
        {
            player.GetDamage(damageToPlayer);
            Destroy(gameObject);
        }
    }
}
