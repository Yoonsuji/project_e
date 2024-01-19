using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class StockWatch : MonoBehaviour
{
    public string Timer = @"00:00";
    public KeyCode KcdPlay = KeyCode.Space;
    private bool IsPlaying;
    public float TotalSeconds;
    public TextMeshProUGUI text;

    private void Start()
    {
        IsPlaying = true;
    }
    void Update()
    {
        /*if(Input.GetKeyDown(KcdPlay))
        {
            IsPlaying = !IsPlaying;
        }*/
        if(IsPlaying)
        {
            Timer = StockWatchTimer();
        }
        if (text)
        {
            text.text = Timer;
        }
    }
    string StockWatchTimer()
    {
        TotalSeconds += Time.deltaTime;
        TimeSpan timespan = TimeSpan.FromSeconds(TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}", timespan.Minutes, timespan.Seconds);

        return timer;
    }
}
