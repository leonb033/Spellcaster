using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public string title;
    [TextArea(10,15)] public string description;
    public Sprite image;
    public bool can_inspect;
    public bool can_use;
    public bool can_pickup;

    private Button button;
    private InteractionMenu interaction_menu;

    void Awake()
    {
        // Create button & set action
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(() => Select());

        // Find gameobjects & components
        interaction_menu =  GameObject.Find("/Canvas/InteractionMenu").GetComponent<InteractionMenu>();

        // Update collider size to fit image
        UpdateCollider();
    }

    void OnValidate()
    {
        GetComponent<Image>().sprite = image;
    }

    void UpdateCollider()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        RectTransform rect_transform = gameObject.GetComponent<RectTransform>();
        collider.size = new Vector2(rect_transform.rect.width, rect_transform.rect.height);
    }

    void ShowMenu()
    {
        // Update menu
        interaction_menu.UpdateMenu(this);
        // Display menu
        interaction_menu.Open();
    }

    void Select()
    {
        print("Select: " + title);
        ShowMenu();
    }

    public void Inspect()
    {
        print("Inspect: " + title);

    }

    public void Use()
    {
        print("Use: " + title);
    }

    public void PickUp()
    {
        print("PickUp: " + title);
    }

}
