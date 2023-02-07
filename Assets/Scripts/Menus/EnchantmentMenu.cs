using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantmentMenu : MonoBehaviour
{
    GameObject key;
    public InteractionMenu interaction_menu;
    
    void Start()
    {
        key = GameObject.Find("/Canvas/Environment/Interactables/Key");
        Close();
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void Enchant()
    {
        print("test");
        key.GetComponent<RectTransform>().sizeDelta = new Vector2(100.0f, 100.0f);
        key.GetComponent<Interactable>().can_enchant = false;
        key.GetComponent<Interactable>().can_pickup = true;
        interaction_menu.UpdateMenu(key.GetComponent<Interactable>());
        Close();
    }
}
