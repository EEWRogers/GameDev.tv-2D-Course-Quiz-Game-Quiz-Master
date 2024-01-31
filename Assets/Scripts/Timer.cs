using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToAnswer = 15f;
    [SerializeField] float timeBetweenQuestions = 3f;
    [SerializeField] Image timerImage;
    public bool isAnsweringQuestion = true;
    public bool loadNextQuestion;
    float timerValue;

    void Start() 
    {
        timerValue = timeToAnswer;
    }

    void Update() 
    {
        UpdateTimer();
        SetTimerFillAmount();
        Debug.Log(timerValue);
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timeBetweenQuestions;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
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

        if (isAnsweringQuestion)
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
