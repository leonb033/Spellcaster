using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    Vocabulary vocabulary;
    Manager manager;

    List<Word> words;

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
    public int skipQuestionCount = 1;
    public int correctAnswerCount = 1;
    public int wrongAnswerCount = 1;

    // Popup Text
    public TMP_Text correctAnswerPopup, wrongAnswerPopup, skipQuestionPopup;
    private float timeToAppear = 1f;
    private float timeToDisappear;

    void Start()
    {
        foreach(Word word in vocabulary.Get(manager.GetSceneName())) {
            words.Insert(Random.Range(0, words.Count), word);
        }        

        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        vocabulary = GameObject.Find("/Manager/Vocabulary").GetComponent<Vocabulary>();
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
            manager.LoadScene("VocabularyResults");
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
            if(i == 0)
            {
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = words[roundCounter].german;
            }
            else{
                int wrongAnswer;
                do {
                    wrongAnswer = Random.Range(0, words.Count);
                }
                while(wrongAnswer == roundCounter);
                options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = words[wrongAnswer].german;
            }
        }
    }

    void GenerateQuestion()
    {
        roundCounter++;
        UpdateRoundCounter();
        //currentQuestionIndex = Random.Range(0, quiz.Count);
        questionImage.sprite = words[roundCounter].image;
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
        print(skipQuestionCount);
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
