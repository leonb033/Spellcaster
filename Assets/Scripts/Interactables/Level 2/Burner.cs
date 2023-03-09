using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : Interactable
{
    bool burning = false;
    GameObject fire_prefab;
    GameObject lens_prefab;
    
    void Start()
    {
        fire_prefab = Resources.Load("Prefabs/Level_2/Fire") as GameObject;
        lens_prefab = Resources.Load("Prefabs/Level_2/Lens") as GameObject;
    }
    
    public override void Use()
    {
        Instantiate(fire_prefab, this.transform);
        burning = true;
        can_use = false;
        UpdateMenu();
    }

    public override void Combine(Item item)
    {
        if (item.interactable.title == "Sand" && burning) {
            GameObject lens = Instantiate(lens_prefab);
            inventory.AddItem(lens.GetComponent<Interactable>());
            Destroy(item.gameObject);
            can_use = true;
            UpdateMenu();
        }
    }
}
