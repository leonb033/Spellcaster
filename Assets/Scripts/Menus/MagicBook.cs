using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagicBook : Window
{
    public List<Word> verbs = new List<Word>();
    
    Manager manager;
    Messages messages;
    Vocabulary vocabulary;
    Transform left;
    Transform right;
    TMP_FontAsset font;

    void Awake()
    {
        manager =       GameObject.Find("/Manager").GetComponent<Manager>();
        messages =      GameObject.Find("/Canvas/GUI/Messages").GetComponent<Messages>();
        vocabulary =    GameObject.Find("/Manager/Vocabulary").GetComponent<Vocabulary>();
        left =          GameObject.Find("/Canvas/GUI/Menus/MagicBook/Page/Left").transform;
        right =         GameObject.Find("/Canvas/GUI/Menus/MagicBook/Page/Right").transform;
        font =          Resources.Load("Fonts/Cihuy") as TMP_FontAsset;
    }

    void Reset()
    {
        // Delete all child elements of left side
        foreach(Transform child in left) {
            Destroy(child.gameObject);
        }
        // Delete all child elements of right side
        foreach(Transform child in right) {
            Destroy(child.gameObject);
        }
    }

    public void ShowNouns()
    {
        Reset();
        // Add nouns
        foreach (var word in vocabulary.Get(manager.GetSceneName()))
        {
            // left
            GameObject german = new GameObject();
            german.transform.SetParent(left);
            TextMeshProUGUI german_text = german.AddComponent<TextMeshProUGUI>();
            german_text.text = word.german;
            german_text.font = font;
            german_text.enableAutoSizing = true;
            german.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            german.GetComponent<RectTransform>().localScale = new Vector2(0.8f, 0.8f);

            // right
            GameObject english = new GameObject();
            english.transform.SetParent(right);
            TextMeshProUGUI english_text = english.AddComponent<TextMeshProUGUI>();
            english_text.text = word.english;
            english_text.font = font;
            english_text.enableAutoSizing = true;
            english.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            english.GetComponent<RectTransform>().localScale = new Vector2(0.8f, 0.8f);
        }
    }

    public void ShowVerbs()
    {
        Reset();
        // Add verbs
        foreach(Word verb in verbs) {
            // left
            GameObject german = new GameObject();
            german.transform.SetParent(left);
            TextMeshProUGUI german_text = german.AddComponent<TextMeshProUGUI>();
            german_text.text = verb.german;
            german_text.font = font;
            german_text.enableAutoSizing = true;
            german.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            german.GetComponent<RectTransform>().localScale = new Vector2(0.8f, 0.8f);

            // right
            GameObject english = new GameObject();
            english.transform.SetParent(right);
            TextMeshProUGUI english_text = english.AddComponent<TextMeshProUGUI>();
            english_text.text = verb.english;
            english_text.font = font;
            english_text.enableAutoSizing = true;
            english.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            english.GetComponent<RectTransform>().localScale = new Vector2(0.8f, 0.8f);
        }
    }

    public void AddVerb(Word verb)
    {
        verbs.Add(verb);
        messages.MagicBookMessage();
    }

    override protected void Init()
    {
        ShowNouns();
    }
}
