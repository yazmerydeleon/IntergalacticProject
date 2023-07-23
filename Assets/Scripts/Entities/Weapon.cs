using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    //private string name;

    //private float damage;

    //private float bulletSpeed;


    //Explicitly Defined Constructor
    //public Weapon()
    //{

    //}

    //Explicitly Defined Constructor Override
    //public Weapon(string name, float damage, float bulletSpeed)
    //{
    //    this.name = name;
    //   // this.damage = damage;
    //    //this.bulletSpeed = bulletSpeed;

    //}


    public void Shoot(GameObject _bullet, PlayableObject _shooter)
    {
        GameObject.Instantiate(_bullet, _shooter.transform.position, _shooter.transform.rotation);
       // tempBullet.GetComponent<Bullet>().SetBullet(damage, bulletSpeed);

    }
}
