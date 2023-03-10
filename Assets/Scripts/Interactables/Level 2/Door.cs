using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactable
{
    public Sprite image_open;
    
    public bool sigel_t;
    public bool sigel_o;
    public bool sigel_d;
    bool open = false;

    Manager manager;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }

    public void RemoveSeal(string letter)
    {
        if (letter == "T") {
            sigel_t = true;
        }
        else if (letter == "O") {
            sigel_o = true;
        }
        else if (letter == "D") {
            sigel_d = true;
        }

        if (sigel_t && sigel_o && sigel_d) {
            can_use = true;
            UpdateMenu();
        }
    }

    public override void Use()
    {
        if (!open) {
            open = true;
            GetComponent<Image>().sprite = image_open;
        }
        else {
            manager.LoadNextScene();
        }
    }
}
