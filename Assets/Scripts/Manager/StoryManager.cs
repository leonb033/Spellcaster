using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    [TextArea(5,10)] public List<string> texts = new List<string>();
    Manager manager;
    TMP_Text text;
    Button button;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        text = GameObject.Find("/Canvas/GUI/Text_Background/Text").GetComponent<TMP_Text>();
        button = GameObject.Find("/Canvas/GUI/Continue").GetComponent<Button>();

        // Set text
        text.text = texts[manager.GetLevelId()];

        // Set button function
        button.onClick.AddListener(() => {
            manager.LoadNextScene();
        });
    }
}
