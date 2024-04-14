using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timerSlider;

    //public Text timerText;
    public float gameTime;

    public bool timerIsRunning;  // Control whether the timer is running

    public float timeRemaining;

    public bool gameFailed;

    private void Start()
    {
        // Initialize the timer but do not start it yet
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        timeRemaining = gameTime; // Initialize remaining time
        gameFailed = false;
    }

    public void OnTimerStart()
    {
        timerIsRunning = true; // Start the timer
    }

    public void OnTimerStop() 
    {
        timerIsRunning = false; // stops the timer
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false; // Stop the timer
                gameFailed = true;
                UpdateTimerDisplay(timeRemaining);
                // Perform any actions after the timer runs out
            }
        }
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timerSlider.value = timeToDisplay;

        //int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        //int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Optionally update the text display if you uncomment the Text timerText and its reference
        //timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    bool getGameFailed()
    { return gameFailed; }

    public void subtractTime()
    { timeRemaining -= 0.5f; }
}
