using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VocabularyTest : Window
{
    public int answers_total = 4;
    public Sprite button_sprite;
    
    Manager manager;
    Vocabulary vocabulary;
    Image image;
    Transform answers;
    InteractionMenu interaction_menu;
    Object button_prefab;
    
    void Awake()
    {
        manager =               GameObject.Find("/Manager").GetComponent<Manager>();
        vocabulary =            GameObject.Find("/Manager/Vocabulary").GetComponent<Vocabulary>();
        image =                 GameObject.Find("/Canvas/GUI/Menus/VocabularyTest/Info/Image").GetComponent<Image>();
        answers =               GameObject.Find("/Canvas/GUI/Menus/VocabularyTest/Answers/Container").transform;
        interaction_menu =      GameObject.Find("/Canvas/GUI/Menus/InteractionMenu").GetComponent<InteractionMenu>();
        button_prefab = Resources.Load("Prefabs/GUI/Button");
    }

    public void Test(Interactable interactable)
    {
        Open();
        image.sprite = interactable.GetImage();

        // Remove old answers
        foreach(Transform child in answers)
        {
            Destroy(child.gameObject);
        }

        // Correct answer
        CreateAnswerButton(interactable.title, interactable);

        // Incorrect answers
        List<string> incorrect = new List<string>();
        // Select random answers from vocabulary
        var words = vocabulary.Get(manager.GetSceneName());
        for (int i = 0; i < answers_total-1; i++)
        {
            string word;
            do {
                word = words[Random.Range(0, words.Count)].german;
            }
            while ((incorrect.Contains(word)) || (word == interactable.title));
            incorrect.Add(word);
        }

        foreach (string word in incorrect)
        {
            CreateAnswerButton(word);
        }
    }

    void CreateAnswerButton(string answer_text, Interactable interactable = null)
    {
        GameObject obj = Instantiate(button_prefab, answers) as GameObject;
        obj.name = "Answer";

        TMP_Text text = obj.transform.GetChild(0).GetComponent<TMP_Text>();
        text.text = answer_text;

        Button button = obj.GetComponent<Button>();

        if (interactable) {
            button.onClick.AddListener(() => {
                interactable.vocabulary_done = true;
                Close();
                interaction_menu.Open();
            });
        }
        else {
            obj.transform.SetSiblingIndex(Random.Range(0, answers.childCount+1));
        }
    }

    override protected void Init() {}
}
