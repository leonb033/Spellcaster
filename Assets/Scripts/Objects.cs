using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objects : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private bool can_inspect;
    [SerializeField] private bool can_use;
    [SerializeField] private bool can_pickup;
    private Button button;


    void Start()
    {
        button = gameObject.AddComponent<Button>();
        print(button);
        button.onClick.AddListener(() => Select());
    }

    void Select()
    {
        print("Menu Popup");
    }

    void Inspect()
    {

    }

    void Use()
    {

    }

    void Pickup()
    {

    }

}
