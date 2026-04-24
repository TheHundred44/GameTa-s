using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI timerText;

    public float elapsedTime = 0f;
    private bool isPaused = false;

    void Update()
    {
        if (!isPaused)
        {
            elapsedTime += Time.deltaTime;
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        // On formate le temps en Minutes : Secondes
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetFinalScore()
    {
        return elapsedTime;
    }
}
