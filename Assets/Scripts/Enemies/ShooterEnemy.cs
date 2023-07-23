 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float rate = 0;
    [SerializeField] private float stoppingDistance = 5.0f;

    private float timerCooldown = 0;
    private float originalSpeed;

    private Transform originPoint;
    private Vector3 destinationPoint;
    private LineRenderer lineRenderer;

    private Transform enemyTransform;

    protected override void Start()
    {
        base.Start();
        originalSpeed = speed;

        // Get the LineRenderer component attached to the GameObject
        lineRenderer = GetComponent<LineRenderer>();
        originPoint = transform;

        // Set the desired LineRenderer properties (you can adjust these to fit your needs)
        lineRenderer.startWidth = 0.04f;
        lineRenderer.endWidth = 0.04f;
        lineRenderer.positionCount = 2; // Two points: origin and destination


        // lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.03f, 1, 0.03f);
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;


    }

    protected override void Update()
    {
        base.Update();

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > stoppingDistance)
        {
            speed = originalSpeed;
            lineRenderer.enabled = false;
        }
        else
        {
            speed = 0f;
            // Set the positions for the LineRenderer
            destinationPoint = target.position;
            lineRenderer.SetPosition(0, originPoint.position);
            lineRenderer.SetPosition(1, destinationPoint);
            lineRenderer.enabled = true;

            if (timerCooldown == 0)
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
