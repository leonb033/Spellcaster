using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VocabularyAnswers : MonoBehaviour
{
    public bool isCorrect = false;
    public VocabularyManager manager;
    private Color startColor;

    void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if(isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            print("Correct!");
            manager.CorrectAnswer();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            print("Wrong!");
        }
    }
}
