using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class VocabularyResults : MonoBehaviour
{
    
    Manager manager;
    VocabularyManager voc_manager;

    private TMP_Text correctAnswers;
    private TMP_Text wrongAnswers;
    private TMP_Text skippedAnswers;
    private TMP_Text endResultWon;
    private TMP_Text endResultLose;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        voc_manager = GameObject.Find("Vocabulary Manager").GetComponent<VocabularyManager>();
        correctAnswers = GameObject.Find("Canvas/Text Panel Background/Text Panel/Correct Answers").GetComponent<TMP_Text>();
        wrongAnswers = GameObject.Find("Canvas/Text Panel Background/Text Panel/Wrong Answers").GetComponent<TMP_Text>();
        skippedAnswers = GameObject.Find("Canvas/Text Panel Background/Text Panel/Skipped Answers").GetComponent<TMP_Text>();
        endResultWon = GameObject.Find("Canvas/Text Panel Background/End Result").GetComponent<TMP_Text>();
        endResultLose = GameObject.Find("Canvas/Text Panel Background/End Result").GetComponent<TMP_Text>();

        CheckResults();
        ShowText();
    }

    void CheckResults()
    {
        if(voc_manager.correctAnswerCount >= 8)
        {
            endResultWon.text = "Congratulations! You did it!";
        }
        else
        {
            endResultLose.text = "Sorry, you have to try again.";
        }
    }

    void ShowText()
    {
        correctAnswers.text = "Correct Answers: " + voc_manager.correctAnswerCount;
        wrongAnswers.text = "Wrong Answers: " + voc_manager.wrongAnswerCount;
        skippedAnswers.text = "Skipped Answers: " + voc_manager.skipQuestionCount;
    }

    public void CheckForNextScene()
    {
        if(voc_manager.correctAnswerCount >= 8)
        {
            manager.LoadScene("Level_2");
        }
        else
        {
            manager.LoadScene("Vocabulary");
        }
    }

}
