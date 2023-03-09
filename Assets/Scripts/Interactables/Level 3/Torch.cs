using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    public GameObject prefab_fire_2;

    public override void Enchant(string spell)
    {
        if (spell == "ignite") {
            Instantiate(prefab_fire_2, this.transform);
            can_enchant = false;
            UpdateMenu();
        }
    }
}
