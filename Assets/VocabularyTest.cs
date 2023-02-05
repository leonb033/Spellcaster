using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyTest : MonoBehaviour
{
    private Image image;
    private Transform answers;
    private InteractionMenu interaction_menu;
    
    void Start()
    {
        Close();
        image =                 transform.Find("Info/Image").GetComponent<Image>();
        answers =               transform.Find("Answers");
        interaction_menu =      transform.Find("/Canvas/InteractionMenu").GetComponent<InteractionMenu>();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Test(Interactable interactable)
    {
        Open();
        image.sprite = interactable.image;
        GameObject obj_button;
        Image img;
        Button button;
        GameObject obj_text;
        TMP_Text text;

        // Remove old answers
        foreach(Transform child in answers)
        {
            Destroy(child.gameObject);
        }

        // Correct answer
        obj_button = new GameObject("Button_Correct");
        img = obj_button.AddComponent<Image>();
        obj_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        obj_button.transform.SetParent(answers);
        button = obj_button.AddComponent<Button>();
        obj_text = new GameObject("Text");
        obj_text.transform.SetParent(obj_button.transform);
        text = obj_text.AddComponent<TextMeshProUGUI>();
        text.text = interactable.title;
        button.onClick.AddListener(() => {
            interactable.vocabulary_done = true;
            Close();
            interaction_menu.Open();
        });

        for (int i = 0; i < interactable.answers.Length; i++)
        {
            obj_button = new GameObject("Button_False_"+i);
            img = obj_button.AddComponent<Image>();
            obj_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            obj_button.transform.SetParent(answers);
            button = obj_button.AddComponent<Button>();
            obj_text = new GameObject("Text");
            obj_text.transform.SetParent(obj_button.transform);
            text = obj_text.AddComponent<TextMeshProUGUI>();
            text.text = interactable.answers[i];
            obj_button.transform.SetSiblingIndex(Random.Range(0, answers.childCount+1));
        }

        /*
        // False answer 1
        obj_button = new GameObject("Button_False_1");
        img = obj_button.AddComponent<Image>();
        obj_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        obj_button.transform.SetParent(answers);
        button = obj_button.AddComponent<Button>();
        obj_text = new GameObject("Text");
        obj_text.transform.SetParent(obj_button.transform);
        text = obj_text.AddComponent<TextMeshProUGUI>();
        text.text = interactable.vocabulary_false_1;
        obj_button.transform.SetSiblingIndex(Random.Range(0, answers.childCount+1));


        // False answer 2
        obj_button = new GameObject("Button_False_2");
        img = obj_button.AddComponent<Image>();
        obj_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        obj_button.transform.SetParent(answers);
        button = obj_button.AddComponent<Button>();
        obj_text = new GameObject("Text");
        obj_text.transform.SetParent(obj_button.transform);
        text = obj_text.AddComponent<TextMeshProUGUI>();
        text.text = interactable.vocabulary_false_2;
        obj_button.transform.SetSiblingIndex(Random.Range(0, answers.childCount+1));

        // False answer 3
        obj_button = new GameObject("Button_False_3");
        img = obj_button.AddComponent<Image>();
        obj_button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
        obj_button.transform.SetParent(answers);
        button = obj_button.AddComponent<Button>();
        obj_text = new GameObject("Text");
        obj_text.transform.SetParent(obj_button.transform);
        text = obj_text.AddComponent<TextMeshProUGUI>();
        text.text = interactable.vocabulary_false_3;
        obj_button.transform.SetSiblingIndex(Random.Range(0, answers.childCount+1));
        */
    }
}
