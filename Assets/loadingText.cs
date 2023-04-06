using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingText : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;
    private int NumberOfDots = 0;
    private float LastSecond;

    [SerializeField] private TextMeshProUGUI loading;

    void Start()
    {
        TimerOn = true;
        LastSecond = TimeLeft;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        string LoadingText = "Loading";

        float seconds = Mathf.FloorToInt(currentTime % 60);
        if (LastSecond - seconds >= 1)
        {
            NumberOfDots += 1;
            LastSecond = seconds;
        }

        for (int i = 0; i < NumberOfDots; i++)
        {
            LoadingText += ".";
        }

        loading.text = LoadingText;
    }
}
