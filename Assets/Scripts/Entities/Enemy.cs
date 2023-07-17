using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    [SerializeField] private float speed;

    private string name;
    private EnemyType enemyType;
    private Vector2 targetOsc;
    private float amplitude;
    private float frequency;

    public Health health;
    public Weapon weapon;

    public static int numberOfEnemies;

    protected Transform target;

    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;

        amplitude = Random.Range(0, 15);

        frequency = Random.Range(0, 10);
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position, speed);
        }
        else
        {
            Move(speed);
        }

    }


    public Enemy()
    {
        AddEnemy();
    }


    public override void Move(Vector2 direction, Vector2 target)
    {

    }

    public override void Move(Vector2 direction, float speed)
    {
        float xpos = target.position.x;
        float ypos = target.position.y + amplitude * Mathf.Sin(frequency * Time.timeSinceLevelLoad);

        targetOsc = new Vector2(xpos, ypos);

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
    }

    public override void Move(float Speed)
    {

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot(Vector3 direction, float speed)
    {

    }

    public virtual void Attack()
    {

    }

    public virtual void Attack(float rate)
    {

    }

    public virtual void AttackAnimation()
    {
        
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    public static void AddEnemy()
    {
        numberOfEnemies++;
    }
    public static void SubtractEnemy()
    {
        numberOfEnemies--;
    }

    public override void GetDamage(float damage)
    {
        StartCoroutine(Die());
    }
}
