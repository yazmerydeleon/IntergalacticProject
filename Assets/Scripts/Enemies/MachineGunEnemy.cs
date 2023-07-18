using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;

    private float stoppingDistance = 5.0f;
    private float timer = 0;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);        

        if (distanceToPlayer > stoppingDistance)
        {
            base.Update();
        }
        else 
        {
            GameObject.Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);           
        }
    }

    //public override void Attack(float rate)
    //{

    //    if (timer == 0)
    //    {
    //        timer += Time.deltaTime;
    //    }

    //    if (timer < rate)
    //    {
    //        timer += Time.deltaTime;
    //        return;
    //    }
    //    else
    //    {
    //        timer = 0;
    //    }


    //}

}
