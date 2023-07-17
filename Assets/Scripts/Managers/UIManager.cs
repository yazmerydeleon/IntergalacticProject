using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.GetInstance().player.healthUpdate += HealthUpdate;

        highScoreText.SetText(GameManager.GetInstance().scoreManager.GetHighScore().ToString());
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        GameManager.GetInstance().player.healthUpdate -= HealthUpdate;
    }

    public void HealthUpdate(float currentHealth)
    {
        healthText.SetText(currentHealth.ToString());
    }

    public void UpdateScore()
    {
        scoreText.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
        
    }

    public void UpdateHighScore()
    {
        highScoreText.SetText(GameManager.GetInstance().scoreManager.GetHighScore().ToString());
    }

}
