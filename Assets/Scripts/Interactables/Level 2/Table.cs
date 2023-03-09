using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : Interactable
{
    GameObject prefab_drawer;

    void Start()
    {
        prefab_drawer = Resources.Load("Prefabs/Level_2/Drawer") as GameObject;
    }
    
    public override void Use()
    {
        Instantiate(prefab_drawer, this.transform);
        can_use = false;
        UpdateMenu();
    }
}
