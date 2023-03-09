using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FairyMenu : Window
{
    [TextArea(5,10)] public List<string> texts = new List<string>();

    Manager manager;
    TMP_Text text;

    void Start()
    {
        manager =       GameObject.Find("/Manager").GetComponent<Manager>();
        text =          GameObject.Find("/Canvas/GUI/Menus/FairyMenu/Text").GetComponent<TMP_Text>();
        text.text =     texts[manager.GetLevelId()-1];
    }

    override protected void Init() {}
}