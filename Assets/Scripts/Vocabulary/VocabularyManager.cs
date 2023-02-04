using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    [System.Serializable]
    public struct Quiz
    {
        public Sprite question;
        public string[] answers;
        public int correctAnswerIndex;
    }

    public List<Quiz> quiz;
    public GameObject[] options;
    public Image questionImage;

    private int currentQuestionIndex;

    // Round Counter
    public TMP_Text roundCounterText;
    private int roundCounter = 0;
    private int maxRound = 10;

    // Popup Text
    public TMP_Text correctAnswerPopup, wrongAnswerPopup, skipQuestionPopup;
    private float timeToAppear = 1f;
    private float timeToDisappear;

    void Start()
    {
        GenerateQuestion();
    }

    void Update()
    {
        if(correctAnswerPopup.enabled && (Time.time >= timeToDisappear))
        {
            correctAnswerPopup.enabled = false;
        }

        if(wrongAnswerPopup.enabled && (Time.time >= timeToDisappear))
        {
            wrongAnswerPopup.enabled = false;
        }

        if(skipQuestionPopup.enabled && (Time.time >= timeToDisappear))
        {
            skipQuestionPopup.enabled = false;
        }
    }

    public void CheckWinCondition()
    {
        if(roundCounter < maxRound)
        {
            NextQuestion();
        }
    }

    void NextQuestion()
    {
        quiz.RemoveAt(currentQuestionIndex);
        GenerateQuestion();
        EnableButtons();
    }

    void GenerateAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<VocabularyAnswers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = quiz[currentQuestionIndex].answers[i];

            if(quiz[currentQuestionIndex].correctAnswerIndex == i+1)
            {
                options[i].GetComponent<VocabularyAnswers>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        roundCounter++;
        UpdateRoundCounter();
        currentQuestionIndex = Random.Range(0, quiz.Count);
        questionImage.sprite = quiz[currentQuestionIndex].question;
        GenerateAnswers();
    }

    void EnableButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetComponent<Button>().enabled = true;            
        }        
    }

    public void DisableButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetComponent<Button>().enabled = false;            
        }
    }

    public void PopupCorrectAnswer()
    {
        correctAnswerPopup.enabled = true;
        timeToDisappear = Time.time + timeToAppear;
    }

    public void PopupWrongAnswer()
    {
        wrongAnswerPopup.enabled = true;
        timeToDisappear = Time.time + timeToAppear;
    }

    void PopupSkipQuestion()
    {
        skipQuestionPopup.enabled = true;
        timeToDisappear = Time.time + timeToAppear;
    }

    void UpdateRoundCounter()
    {
        roundCounterText.text = roundCounter + " / " + maxRound;
    }

    public void SkipQuestion()
    {
        NextQuestion();
        PopupSkipQuestion();
    }
}
