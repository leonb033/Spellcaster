using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Interactable : MonoBehaviour, IDropHandler
{
    public string title;
    [TextArea(10,15)] public string description;

    public bool can_inspect;
    public bool can_use;
    public bool can_pickup;
    public bool can_enchant;

    public bool vocabulary_done = false;

    protected Transform interactables;
    protected Button button;
    protected Inventory inventory;
    protected Transform inventory_items;
    protected InteractionMenu interaction_menu;
    protected VocabularyTest vocabulary_test;
    protected EnchantmentMenu enchantment_menu;

    protected AudioManager audio_manager;
    protected AudioClip select_sound;
    protected AudioClip combine_failed_sound;

    void Awake()
    {
        // Add box collider
        gameObject.AddComponent<BoxCollider2D>();
        // Create button & set action
        button = gameObject.AddComponent<Button>();
        button.onClick.AddListener(() => Select());

        // Find gameobjects & components
        interactables =     GameObject.Find("/Canvas/Environment/Interactables").transform;
        inventory =         GameObject.Find("/Canvas/GUI/Menus/Inventory").GetComponent<Inventory>();
        inventory_items =   GameObject.Find("/Canvas/GUI/Menus/Inventory/View/Items").transform;
        interaction_menu =  GameObject.Find("/Canvas/GUI/Menus/InteractionMenu").GetComponent<InteractionMenu>();
        vocabulary_test =   GameObject.Find("/Canvas/GUI/Menus/VocabularyTest").GetComponent<VocabularyTest>();
        enchantment_menu =  GameObject.Find("/Canvas/GUI/Menus/EnchantmentMenu").GetComponent<EnchantmentMenu>();
        audio_manager =     GameObject.Find("/Manager").GetComponent<AudioManager>();

        // Load sounds
        select_sound = Resources.Load("Sounds/Interactables/select", typeof(AudioClip)) as AudioClip;
        combine_failed_sound = Resources.Load("Sounds/UI/error", typeof(AudioClip)) as AudioClip;

        // Update collider size to fit image
        UpdateCollider();
    }

    void UpdateCollider()
    {
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        RectTransform rect_transform = gameObject.GetComponent<RectTransform>();
        collider.size = new Vector2(rect_transform.rect.width, rect_transform.rect.height);
    }

    void Select()
    {
        // Play sound
        audio_manager.Play(select_sound);
        
        // Update menu
        UpdateMenu();

        // Open vocabulary test if not answered already
        if (vocabulary_done) {
            interaction_menu.Open();
        }
        else {
            vocabulary_test.Test(this);
        }
    }

    public Sprite GetImage()
    {
        return gameObject.GetComponent<Image>().sprite;
    }

    public void SetImage(Sprite image)
    {
        gameObject.GetComponent<Image>().sprite = image;
    }

    public void UpdateMenu()
    {
        interaction_menu.UpdateMenu(this);
    }
    
    public void OpenInEnchantmentMenu()
    {
        enchantment_menu.Open(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Combine(eventData.pointerDrag.GetComponent<Item>());
    }

    public void PickUp()
    {
        inventory.AddItem(this);
        can_pickup = false;
        interaction_menu.UpdateMenu(this);
        Destroy(gameObject);
    }

    public virtual void Inspect() {}

    public virtual void Use() {}

    public virtual void Combine(Item item) {}

    public virtual void Enchant(string spell) {}
}