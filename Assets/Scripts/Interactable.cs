using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IDropHandler
{
    public string title;
    [TextArea(10,15)] public string description;
    public Sprite image;
    public string[] answers;
    
    public bool can_inspect;
    public bool can_use;
    public bool can_pickup;
    public bool can_enchant;

    public bool vocabulary_done = false;

    public GameObject item_prefab;

    private Button button;
    private Transform inventory_items;
    private InteractionMenu interaction_menu;
    private VocabularyTest vocabulary_test;

    private EnchantmentMenu enchantment_menu;

    void Awake()
    {
        // Create button & set action
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(() => Select());

        // Find gameobjects & components
        inventory_items =   GameObject.Find("/Canvas/Inventory/View/Items").transform;
        interaction_menu =  GameObject.Find("/Canvas/InteractionMenu").GetComponent<InteractionMenu>();
        vocabulary_test =   GameObject.Find("/Canvas/VocabularyTest").GetComponent<VocabularyTest>();

        enchantment_menu = GameObject.Find("/Canvas/EnchantmentMenu").GetComponent<EnchantmentMenu>();

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
        // Display menu
        interaction_menu.Open();
    }

    void Select()
    {
        // Update menu
        interaction_menu.UpdateMenu(this);
        if (vocabulary_done) {
            ShowMenu();
        }
        else {
            if (!vocabulary_test.isActiveAndEnabled) {
                vocabulary_test.Test(this);
            }
        }
    }

    public void Inspect()
    {
        print("Inspect: " + title);
        can_inspect = false;
        interaction_menu.UpdateMenu(this);
    }

    public void Use()
    {
        print("Use: " + title);
    }

    public void PickUp()
    {
        print("PickUp: " + title);
        GameObject item = Instantiate(item_prefab, inventory_items);
        item.GetComponent<Image>().sprite = image;
        Destroy(gameObject);
    }

    public void Enchant()
    {
        enchantment_menu.Open();
        print("Enchant: " + title);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name);
    }
}
