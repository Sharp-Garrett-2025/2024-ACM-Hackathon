using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider timerSlider;
    //public Text timerText;
    public float gameTime;

    private bool stopTimer;
    void Start()
    {

        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;


    }

    void Update()
    {
        float time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        //string textTime = string.Format("{0:0}: {0:0}", minutes, seconds);

        if(time <= 0)
        {
            stopTimer = true;
        }
        else
        {
            //timerText.text = textTime;
            timerSlider.value = time;

        }
    }
}
