using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class VocabularyAnswers : MonoBehaviour
{
    public VocabularyManager manager;
    public bool isCorrect = false;
    private Color startColor;
    private float showColorForSeconds = 1f;

    void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        StartCoroutine(SetAnswer());
        manager.DisableButtons();
    }

    IEnumerator SetAnswer()
    {
        if(isCorrect)
        {
            manager.PopupCorrectAnswer();
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            manager.PopupWrongAnswer();
            GetComponent<Image>().color = Color.red;
        }

        yield return new WaitForSeconds(showColorForSeconds);
        ResetColor();
        manager.CheckWinCondition();
    }

    void ResetColor()
    {
        GetComponent<Image>().color = startColor;
    }
    
}
