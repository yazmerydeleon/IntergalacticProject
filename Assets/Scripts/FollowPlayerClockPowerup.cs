using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayerClockPowerup : MonoBehaviour
{
    [SerializeField] private Image timerImage; // The Image component you're adjusting the fillAmount of
    [SerializeField] private float timeDuration = 5f; // The total time of the countdown
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject powerupInnerSprite;


    public bool IsEnabled = false;
    public float Rate = 0.1f;

    private const string playerTag = "Player";

    private float currentTime;
   // private bool isCountdownActive;

    void Start()
    {               
        timerImage.enabled = false;
        currentTime = timeDuration;
        timerImage.type = Image.Type.Filled;
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            // Start the countdown when the player enters the trigger
            IsEnabled = true;
            // Show the timer image when the countdown starts
            timerImage.fillAmount = 1f;
            timerImage.enabled = true;    
            powerupInnerSprite.SetActive(false);

        }
    }

    void Update()
    {
        if(IsEnabled) 
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                timerImage.fillAmount = currentTime / timeDuration;
            }
            else if (currentTime <= 0)
            {
                timerImage.fillAmount = 0;
                IsEnabled = false;
            }

           // timerImage.transform.position = playerTransform.position;
           // Debug.Log("timerImage.transform.position " + timerImage.transform.position);
        }        
    }

}
