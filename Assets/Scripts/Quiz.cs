using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentquizQuestion;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerNumber;

    [Header("Button Colours")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Timer timer;

    [Header("ScoreKeeper")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] ScoreKeeper scoreKeeper;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    void Start() 
    {
       GetRandomQuestion();
       DisplayQuestion();
       progressBar.maxValue = questions.Count;
       progressBar.value = 0;
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
            scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
            ToggleAnswerButtonInteractability(false);
        }
    }

    void GetNextQuestion()
    {
        progressBar.value++;
        if (questions.Count <= 0)
        {
            isComplete = true;
        }
        if (questions.Count > 0)
        {
        ToggleAnswerButtonInteractability(true);
        SetDefaultButtonSprites();
        GetRandomQuestion();
        DisplayQuestion();
        }
    }

    void DisplayQuestion()
    {
        scoreKeeper.IncrementQuestionsSeen();
        questionText.text = currentquizQuestion.Question;

        for(int answerNumber = 0; answerNumber < answerButtons.Length; answerNumber++)
        {
            TextMeshProUGUI buttonText = answerButtons[answerNumber].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentquizQuestion.GetAnswer(answerNumber);
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count-1);
        currentquizQuestion = questions[index];

        if (questions.Contains(currentquizQuestion))
        {
            questions.Remove(currentquizQuestion);
        }
    }

    public void OnAnswerSelected(int answerNumber)
    {
        timer.SkipTimer();

        DisplayAnswer(answerNumber);

        ToggleAnswerButtonInteractability(false);
    }

    void DisplayAnswer(int answerNumber)
    {
        Image correctAnswerButton = answerButtons[currentquizQuestion.CorrectAnswerNumber].GetComponent<Image>();
        correctAnswerButton.sprite = correctAnswerSprite;
        correctAnswerNumber = currentquizQuestion.CorrectAnswerNumber;

        if (answerNumber == correctAnswerNumber)
        {
            scoreKeeper.IncrementCorrectAnswers();
            questionText.text = "Correct!";
        }
        else
        {
            string correctAnswer = currentquizQuestion.GetAnswer(correctAnswerNumber);
            questionText.text = "Incorrect! The correct answer was: \n" + correctAnswer;
        }
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
