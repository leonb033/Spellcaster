using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTorch : Interactable
{
    public GameObject prefab_fire_1;

    public override void Enchant(string spell)
    {
        if (spell == "ignite") {
            Instantiate(prefab_fire_1, this.transform);
            can_enchant = false;
            UpdateMenu();
        }
    }
}
