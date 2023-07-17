using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    [SerializeField] private float destroyDelay;
    //Composition (part of) relationship
    public Health health = new Health();


    // Aggregation (has a) relationship 
    public Weapon weapon;



    public abstract void Move(Vector2 direction, Vector2 target);


    //overrides
    public virtual void Move(Vector2 direction)
    {
        // Do one thing using direction
    }

    public virtual void Move(Vector2 direction, float speed)
    {
        // Do one thing using direction
    }

    public virtual void Move(float speed)
    {
        // do another thing using speed
    }


    public abstract void Shoot(Vector3 direction, float speed);


    public virtual IEnumerator Die()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    public abstract void GetDamage(float damage);

}
