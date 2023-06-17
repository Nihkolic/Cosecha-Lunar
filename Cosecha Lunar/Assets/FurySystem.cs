using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurySystem : MonoBehaviour
{
    public static bool FURY_IS_ACTIVE;
    [SerializeField] private GameObject furyBar;
    bool furyHasBeenActivated;
    void Start()
    {
        FURY_IS_ACTIVE = false;
        ResetTimer();
        furyBar.SetActive(false);
    }
    void Update()
    {
        Fury();
        Timer();
    }
    void Fury()
    {
        if (FURY_IS_ACTIVE && !furyHasBeenActivated)
        {
            StartTimer();
            furyBar.SetActive(true);
            furyHasBeenActivated = true;
        }
    }
    public float totalTime = 10f; // Total time for the timer
    public Image timerImage; // Reference to the timer image

    private float currentTime = 0f; // Current time of the timer
    private bool isRunning = false;
    void Timer()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerImage();

            if (currentTime <= 0f)
            {
                // Timer has reached zero
                isRunning = false;
                ResetTimer();
                
            }
        }
    }
    public void StartTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        furyHasBeenActivated = false;
        FURY_IS_ACTIVE = false;
        furyBar.SetActive(false);
    }

    private void UpdateTimerImage()
    {
        float fillAmount = currentTime / totalTime;
        timerImage.fillAmount = fillAmount;
    }
}
