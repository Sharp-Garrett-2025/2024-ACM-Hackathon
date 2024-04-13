using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public float maxTime = 30f;
    private float timeLeft;
    private Image timerBar;

    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = maxTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        }
        else
        {
            // Optionally handle what happens when the time runs out
            Debug.Log("Time's up!");
        }
    }
}

