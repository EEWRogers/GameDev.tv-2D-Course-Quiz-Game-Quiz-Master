using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject 
{
    [SerializeField] [TextArea (2,6)] string question = "Enter new question text here";
    public string Question { get { return question; } }

    [SerializeField] string[] answers = new string[4];

    [SerializeField] [Range(0,3)] int correctAnswerNumber;
    public int CorrectAnswerNumber { get { return correctAnswerNumber; } }

    public string GetAnswer(int answerNumber)
    {
        return answers[answerNumber];
    }
}
