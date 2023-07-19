using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float rate = 0;
    [SerializeField] private float stoppingDistance = 5.0f;

    private float timerCooldown = 0;
    private float originalSpeed;


    protected override void Start()
    {
        base.Start();
        originalSpeed = speed;
    }

    protected override void Update()
    {
        base.Update();

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);        

        if (distanceToPlayer > stoppingDistance)
        {
            speed = originalSpeed;
        }
        else 
        {
           speed = 0f;

            if(timerCooldown == 0)
            {
                GameObject.Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
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
    }

}
