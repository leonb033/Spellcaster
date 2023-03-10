using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    Vocabulary vocabulary;
    Manager manager;
    public List<Word> words = new List<Word>();
    List<Vector2> button_positions = new List<Vector2>();
    Color startColor;

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
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        vocabulary = GameObject.Find("/Manager/Vocabulary").GetComponent<Vocabulary>();
        DontDestroyOnLoad(this.gameObject);
        // Set button start color
        startColor = Color.white;
        // Create new list of word in random order
        foreach(Word word in vocabulary.Get("Level_"+manager.GetLevelId())) {
            words.Insert(Random.Range(0, words.Count), word);
        }
        maxRound = words.Count;
        // Set button positions
        button_positions.Add(new Vector2(-330, -100));
        button_positions.Add(new Vector2(330, -100));
        button_positions.Add(new Vector2(330, -300));
        button_positions.Add(new Vector2(-330, -300));
        // Generate new question
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
        else if(roundCounter >= maxRound)
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

    IEnumerator CorrectAnswer(Image image)
    {
        print("CorrectAnswer");
        correctAnswerCount++;
        PopupCorrectAnswer();
        image.color = Color.green;
        DisableButtons();
        yield return new WaitForSeconds(1.0f);
        image.color = startColor;
        CheckWinCondition();
    }

    IEnumerator IncorrectAnswer(Image image)
    {
        print("IncorrectAnswer");
        wrongAnswerCount++;
        PopupWrongAnswer();
        image.color = Color.red;
        DisableButtons();
        yield return new WaitForSeconds(1.0f);
        image.color = startColor;
        CheckWinCondition();
    }

    void GenerateAnswers()
    {
        // Randomize posititions
        List<Vector2> positions = new List<Vector2>();
        foreach(Vector2 pos in button_positions) {
            positions.Insert(Random.Range(0, positions.Count), pos);
        }
        // Update buttons
        int i = 0;
        List<int> wrongAnswers = new List<int>();
        foreach(GameObject obj in options)
        {
            Button button = obj.GetComponent<Button>();
            TMP_Text text = obj.transform.GetChild(0).GetComponent<TMP_Text>();
            obj.GetComponent<RectTransform>().localPosition = positions[i];
            button.onClick.RemoveAllListeners();
            if (i == 0)
            {
                text.text = words[roundCounter].german;
                button.onClick.AddListener(() => {
                    StartCoroutine(CorrectAnswer(obj.GetComponent<Image>()));
                });
            }
            else {
                int wrongAnswer;
                do {
                    wrongAnswer = Random.Range(0, words.Count);
                }
                while (wrongAnswer == roundCounter || wrongAnswers.Contains(wrongAnswer));
                wrongAnswers.Add(wrongAnswer);
                text.text = words[wrongAnswer].german;
                button.onClick.AddListener(() => {
                    StartCoroutine(IncorrectAnswer(obj.GetComponent<Image>()));
                });
            }
            i++;
        }
    }

    void GenerateQuestion()
    {
        UpdateRoundCounter();
        //currentQuestionIndex = Random.Range(0, quiz.Count);
        questionImage.sprite = words[roundCounter].image;
        GenerateAnswers();
        roundCounter++;
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
