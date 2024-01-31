using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
[SerializeField] QuestionSO quizQuestion;
[SerializeField] TextMeshProUGUI questionText;
[SerializeField] GameObject[] answerButtons;

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
}
