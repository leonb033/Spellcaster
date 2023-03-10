using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Interactable
{
    public GameObject prefab_fire_2;

    Scene3Manager scene3manager;

    void Start()
    {
        scene3manager = GameObject.Find("/Scene3Manager").GetComponent<Scene3Manager>();
    }

    public override void Enchant(string spell)
    {
        if (spell == "ignite") {
            Instantiate(prefab_fire_2, this.transform);
            can_enchant = false;
            scene3manager.torch_2 = true;
            scene3manager.Check();
            UpdateMenu();
        }
    }
}
