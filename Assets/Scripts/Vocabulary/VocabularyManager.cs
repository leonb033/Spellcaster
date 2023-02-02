using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyManager : MonoBehaviour
{
    public List<VocabularyQnA> QnA;
    public GameObject[] options;
    public int currentQuestionIndex;

    public Sprite questionImage;

    void Start()
    {
        GenerateQuestion();
    }

    public void CorrectAnswer()
    {
        QnA.RemoveAt(currentQuestionIndex);
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<VocabularyAnswers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestionIndex].answers[i];

            if(QnA[currentQuestionIndex].correctAnswerIndex == i+1)
            {
                options[i].GetComponent<VocabularyAnswers>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        currentQuestionIndex = Random.Range(0, QnA.Count);

        questionImage = QnA[currentQuestionIndex].question;
        SetAnswers();
    }
}
