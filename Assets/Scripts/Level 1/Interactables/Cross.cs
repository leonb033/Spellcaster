using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : Interactable
{
    Sprite image_broken;
    GameObject stick_prefab;
    
    void Start()
    {
        image_broken = Resources.Load("Sprites/Cross_Broken") as Sprite;
        stick_prefab = Resources.Load("Prefabs/Level_1/Stick") as GameObject;
    }

    public override void Use()
    {
        SetImage(image_broken);
        can_use = false;
        UpdateMenu();
        GameObject stick = Instantiate(stick_prefab, interactables);
    }
}
