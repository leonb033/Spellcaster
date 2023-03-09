using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class House : Interactable
{
    public Sprite image_open;

    Manager manager;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }

    public void Open()
    {
        GetComponent<Image>().sprite = image_open;
        can_use = true;
    }

    public override void Use()
    {
        manager.LoadNextScene();
    }
}
