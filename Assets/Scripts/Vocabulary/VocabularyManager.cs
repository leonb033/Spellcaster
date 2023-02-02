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
    public int currentQuestionIndex;

    public Sprite questionImage;

    void Start()
    {
        GenerateQuestion();
    }

    public void CorrectAnswer()
    {
        quiz.RemoveAt(currentQuestionIndex);
        GenerateQuestion();
    }

    void SetAnswers()
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
        currentQuestionIndex = Random.Range(0, quiz.Count);

        questionImage = quiz[currentQuestionIndex].question;
        SetAnswers();
    }
}
