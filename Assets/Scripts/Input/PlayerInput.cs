using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player player;
    private float horizontal, vertical;
    private Vector2 lookTarget;    

    [SerializeField] private FollowPlayerClockPowerup clockPowerup;

    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        lookTarget = Input.mousePosition;

        if (clockPowerup.IsEnabled) //Temporary player power up high rate shoot
        {
            if (Input.GetMouseButton(0))
            {
                player.Shoot(Vector3.zero, clockPowerup.Rate);
                Debug.Log("HighRate");

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                player.Shoot(Vector3.zero, 0);
                Debug.Log("Shoot");

            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            // if nuke > 0
            NukePowerup.DestroyEntitiesWithDifferentTag();
            GameManager.GetInstance().pickupManager.DecrementPowerupScore();
        }
    }

    private void FixedUpdate()
    {
        player.Move(new Vector2(horizontal, vertical), lookTarget);
    }
}
