using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telescope : Interactable
{
    public GameObject prefab_starcard_o;
    
    public override void Use()
    {
        GameObject starcard_o = Instantiate(prefab_starcard_o);
        inventory.AddItem(starcard_o.GetComponent<Interactable>());
        can_use = false;
        UpdateMenu();
    }

    public override void Combine(Item item)
    {
        if (item.interactable.title == "Linse") {
            can_use = true;
            UpdateMenu();
            Destroy(item.gameObject);
        }
    }
}
