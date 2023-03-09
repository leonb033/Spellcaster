using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHolder : Interactable
{
    public GameObject prefab_bone_torch;
    
    public override void Combine(Item item)
    {
        if (item.interactable.title == "Knochen Fackel") {
            GameObject bone_torch = Instantiate(prefab_bone_torch, this.transform);
            Destroy(item.gameObject);
        }
    }
}
