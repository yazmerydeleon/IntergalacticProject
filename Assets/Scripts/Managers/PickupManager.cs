using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupManager : MonoBehaviour
{
    private int powerupScore;

    public UnityEvent OnPowerupScoreUpdated;
    public UnityEvent OnGunPowerupPicked;

    public int GetPowerupScore()
    {
        return powerupScore;
    }

    public void IncrementPowerupScore()
    {
        powerupScore++;
        Debug.Log(powerupScore);
        OnPowerupScoreUpdated?.Invoke();

    }
    public void DecrementPowerupScore()
    {
        powerupScore--;
        Debug.Log(powerupScore);
        OnPowerupScoreUpdated?.Invoke();
    }

    public float GunPowerTimer()
    {
        return Time.time;
    }
}
