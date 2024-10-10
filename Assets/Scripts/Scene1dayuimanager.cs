using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Scene1dayuimanager : MonoBehaviour
{
    [Header("Speedometer")]
    public float speed;
    public Slider speedSlider;
    public TextMeshProUGUI speedtext;
    public Rigidbody car;

    [Header("TimerMeter")]
    public float timerstart = 600f;
    public float timernow;
    public Slider timerSlider;
    public TextMeshProUGUI timertext;

    [Header("WorldTime")]
    public TextMeshProUGUI worldTimeText; 
    public float worldTimeUpdate;
    public float worldTimeStart;
    public float startTimeInSeconds = 7 * 3600f; 
    public float worldTimeSpeed = 12f; 

    private void Start()
    {
        timernow = timerstart;
        worldTimeUpdate = startTimeInSeconds;
    }

    private void Update()
    {
        //speedometer
        speed = car.velocity.magnitude * 3.6f;
        speedSlider.value = speed;
        var a = speed.ToString("#");

        if (speed < 2)
        {
            speedtext.text = "0";
        }
        else
        {
            a = speed.ToString("#");
            speedtext.text = a;
        }

        //timer
        timernow -= Time.deltaTime;
        timerSlider.value = timernow;
        var convers = timernow / 5;
        var b = convers.ToString("#");
        timertext.text = b;

        //TimeSpan time = TimeSpan.FromSeconds(timernow) * 120f;

        //// Format menjadi jam:menit:detik
        //string timeFormatted = string.Format("{0:00}:{1:00}:{2:00}", time.Hours, time.Minutes, time.Seconds);

        //timertext.text = timeFormatted;

        ////world time
        ////getworldtime();
        hitungwaktu();
    }

    void hitungwaktu()
    {
        worldTimeUpdate += Time.deltaTime * worldTimeSpeed;

        float currentTimeInSeconds = startTimeInSeconds + worldTimeUpdate;

       
        int hours = Mathf.FloorToInt(currentTimeInSeconds / 3600f) % 24;
        int minutes = Mathf.FloorToInt((currentTimeInSeconds % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(currentTimeInSeconds % 60f);

       
        string timeFormatted = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
        worldTimeText.text = timeFormatted;
    }
}