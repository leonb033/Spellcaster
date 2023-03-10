using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneTorch : Interactable
{
    public GameObject prefab_fire_1;

    Scene3Manager scene3manager;

    void Start()
    {
        scene3manager = GameObject.Find("/Scene3Manager").GetComponent<Scene3Manager>();
    }

    public override void Enchant(string spell)
    {
        if (spell == "ignite") {
            Instantiate(prefab_fire_1, this.transform);
            can_enchant = false;
            scene3manager.torch_1 = true;
            scene3manager.Check();
            UpdateMenu();
        }
    }
}
