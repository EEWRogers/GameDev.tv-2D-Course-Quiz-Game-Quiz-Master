using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO quizQuestion;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerNumber;

    [Header("Button Colours")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Timer timer;

    void Start() 
    {
        DisplayQuestion();
    }

    void Update() 
    {
        if (timer.loadNextQuestion)
        {
            timer.loadNextQuestion = false;
            GetNextQuestion();
        }

        if (!timer.displayingQuestion)
        {
            ToggleAnswerButtonInteractability(false);
        }
    }

    void GetNextQuestion()
    {
        ToggleAnswerButtonInteractability(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void DisplayQuestion()
    {
        questionText.text = quizQuestion.Question;

        for(int answerNumber = 0; answerNumber < answerButtons.Length; answerNumber++)
        {
            TextMeshProUGUI buttonText = answerButtons[answerNumber].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = quizQuestion.GetAnswer(answerNumber);
        }
    }

    public void OnAnswerSelected(int answerNumber)
    {
        timer.SkipTimer();

        Image correctAnswerButton = answerButtons[quizQuestion.CorrectAnswerNumber].GetComponent<Image>();
        correctAnswerButton.sprite = correctAnswerSprite;
        correctAnswerNumber = quizQuestion.CorrectAnswerNumber;

        if (answerNumber == correctAnswerNumber)
        {
            questionText.text = "Correct!";
        }
        else
        {
            string correctAnswer = quizQuestion.GetAnswer(correctAnswerNumber);
            questionText.text = "Incorrect! The correct answer was: \n" + correctAnswer;
        }

        ToggleAnswerButtonInteractability(false);
    }

    void ToggleAnswerButtonInteractability(bool state)
    {
        for (int button = 0; button < answerButtons.Length; button++)
        {
            Button answerButton = answerButtons[button].GetComponent<Button>();
            answerButton.interactable = state;
        }
    }

    void SetDefaultButtonSprites()
    {
        for (int button = 0; button < answerButtons.Length; button++)
        {
            Image buttonImage = answerButtons[button].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
