using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int highScore;

    public UnityEvent onScoreUpdated;
    public UnityEvent OnHighScoreUpdated;

    // Start is called before the first frame update
    void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void IncrementScore()
    {
        score++;
        onScoreUpdated?.Invoke();

        if(score > highScore)
        {
            highScore = score;
            OnHighScoreUpdated?.Invoke();

            SetHighScore();
        }
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

}
