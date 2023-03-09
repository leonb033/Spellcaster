using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globe : Interactable
{
    public Sprite image_open;
    public GameObject prefab_starcard_d;
    
    public override void Combine(Item item)
    {
        if (item.interactable.title == "Schlüssel")
        {
            GetComponent<Image>().sprite = image_open;
            GameObject starcard_d = Instantiate(prefab_starcard_d);
            inventory.AddItem(starcard_d.GetComponent<Interactable>());
            Destroy(item.gameObject);
        }
    }
}
