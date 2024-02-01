using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer = 15f;
    [SerializeField] float timeBetweenQuestions = 5f;
    [SerializeField] Image timerImage;
    public bool displayingQuestion = true;
    public bool loadNextQuestion = false;
    float timerValue;

    void Start() 
    {
        timerValue = timeToAnswer;
        displayingQuestion = true;
    }

    void Update() 
    {
        UpdateTimer();
        SetTimerFillAmount();
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(displayingQuestion)
        {
            if (timerValue <= 0)
            {
                displayingQuestion = false;
                timerValue = timeBetweenQuestions;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                displayingQuestion = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }
    }

    public void SkipTimer()
    {
        timerValue = 0;
    }

    void SetTimerFillAmount()
    {
        float timerPercentage;

        if (displayingQuestion)
        {
            timerPercentage = timerValue / timeToAnswer;
        }
        else
        {
            timerPercentage = timerValue / timeBetweenQuestions;
        }

        timerImage.fillAmount = timerPercentage;
    }
}
