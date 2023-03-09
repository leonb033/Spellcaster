using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : Interactable
{
    public GameObject prefab_bone_torch;

    public override void Combine(Item item)
    {
        if (item.interactable.title == "Knochen") {
            GameObject bone_torch = Instantiate(prefab_bone_torch);
            inventory.AddItem(bone_torch.GetComponent<Interactable>());
            Destroy(item.gameObject);
            Destroy(this.gameObject);
            UpdateMenu();
        }
    }
}
