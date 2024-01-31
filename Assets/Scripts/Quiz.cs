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
int correctAnswerNumber;

void Start()
    {
        questionText.text = quizQuestion.Question;

        PopulateAnswerButtons();

    }

    void PopulateAnswerButtons()
    {
        for(int answerNumber = 0; answerNumber < answerButtons.Length; answerNumber++)
        {
            TextMeshProUGUI buttonText = answerButtons[answerNumber].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = quizQuestion.GetAnswer(answerNumber);
        }
    }

    public void OnAnswerSelected(int answerNumber)
    {
        Image buttonImage = answerButtons[quizQuestion.CorrectAnswerNumber].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
        correctAnswerNumber = quizQuestion.CorrectAnswerNumber;

        if(answerNumber == quizQuestion.CorrectAnswerNumber)
        {
            questionText.text = "Correct!";
        }
        else
        {
            string correctAnswer = quizQuestion.GetAnswer(correctAnswerNumber);
            questionText.text = "Incorrect! The correct answer was: \n" + correctAnswer;
        }
    }
}
