using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPowerup : MonoBehaviour
{
    

    [SerializeField] private float countdownDuration = 5f; 

    private bool countdownActive = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
