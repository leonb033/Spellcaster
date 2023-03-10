using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{
    public bool torch_1 = false;
    public bool torch_2 = false;
    public GameObject prefab_wizard;
    public Transform interactables;

    public void Check()
    {
        if (torch_1 && torch_2) {
            Instantiate(prefab_wizard, interactables);
        }
    }
}
