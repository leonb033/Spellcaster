using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public Button skipButton;
    public Button exitButton;

    private int currentQuestionIndex;

    // Round Counter
    public TMP_Text roundCounterText;
    private int roundCounter = 0;
    private int maxRound = 10;
    public int skipQuestionCount = 0;
    public int correctAnswerCount = 0;
    public int wrongAnswerCount = 0;

    // Popup Text
    public TMP_Text correctAnswerPopup, wrongAnswerPopup, skipQuestionPopup;
    private float timeToAppear = 1f;
    private float timeToDisappear;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GenerateQuestion();
    }

    void Update()
    {
        try {
            if(correctAnswerPopup.enabled && (Time.time >= timeToDisappear))   
            {
                correctAnswerPopup.enabled = false;
            }
        }
        catch{}

        try {
            if(wrongAnswerPopup.enabled && (Time.time >= timeToDisappear))
            {
                wrongAnswerPopup.enabled = false;
            }
        }
        catch{}

        try{
            if(skipQuestionPopup.enabled && (Time.time >= timeToDisappear))
            {
                skipQuestionPopup.enabled = false;
            }
        }
        catch{}

    }

    public void CheckWinCondition()
    {
        if(roundCounter < maxRound)
        {
            NextQuestion();
        }
        else if(roundCounter == maxRound)
        {
            SceneManager.LoadScene("VocabularyResults");
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

        skipButton.enabled = true;
        exitButton.enabled = true; 
    }

    public void DisableButtons()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetComponent<Button>().enabled = false;            
        }

        skipButton.enabled = false;
        exitButton.enabled = false;
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
        DisableButtons();
    }

    void UpdateRoundCounter()
    {
        roundCounterText.text = roundCounter + " / " + maxRound;
    }

    public void SkipQuestion()
    {
        skipQuestionCount++;
        StartCoroutine(SkipQuestionDelay());
        NextQuestion();
        PopupSkipQuestion();
    }

    IEnumerator SkipQuestionDelay()
    {
        yield return new WaitForSeconds(1f);
        EnableButtons();
    }
}
