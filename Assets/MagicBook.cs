using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicBook : MonoBehaviour
{
    [Serializable]
    public struct  Word
    {
        public string german;
        public string english;
    }
    
    [SerializeField]
    List<Word> words;
    Transform left;
    Transform right;

    void Start()
    {
        left = transform.Find("Left");
        right = transform.Find("Right");
        
        foreach (Word word in words)
        {
            GameObject german = new GameObject();
            german.transform.SetParent(left);
            TextMeshProUGUI german_text = german.AddComponent<TextMeshProUGUI>();
            german_text.text = word.german;
            german.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);

            GameObject english = new GameObject();
            english.transform.SetParent(right);
            TextMeshProUGUI english_text = english.AddComponent<TextMeshProUGUI>();
            english_text.text = word.english;
            english.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        }

        Close();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
