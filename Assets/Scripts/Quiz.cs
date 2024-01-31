using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
[SerializeField] QuestionSO quizQuestion;
[SerializeField] TextMeshProUGUI questionText;
[SerializeField] GameObject[] answerButtons;
[SerializeField] Sprite defaultAnswerSprite;
[SerializeField] Sprite correctAnswerSprite;
[SerializeField] Timer timer;
int correctAnswerNumber;

void Start()
    {
        DisplayQuestion();

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
        Image correctAnswerButtonImage = answerButtons[quizQuestion.CorrectAnswerNumber].GetComponent<Image>();
        correctAnswerButtonImage.sprite = correctAnswerSprite;
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
