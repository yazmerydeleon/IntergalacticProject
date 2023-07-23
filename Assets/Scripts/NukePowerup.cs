using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NukePowerup : MonoBehaviour
{
    private const string playerTag = "Player";

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {       
        if (other.tag == playerTag)
        {
            GameManager.GetInstance().pickupManager.IncrementPowerupScore();
            Destroy(gameObject);
        }     

    }

    public static void DestroyEntitiesWithDifferentTag()
    {
        //GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach(GameObject gameObject in allGameObjects) 
        {
            if (gameObject.layer == LayerMask.NameToLayer("Enemy") || gameObject.layer == LayerMask.NameToLayer("Pickup"))
            {
                Destroy(gameObject);
            }
        }
    }
}
