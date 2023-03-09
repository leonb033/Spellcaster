using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Window
{
    public AudioClip item_sound;
    
    Manager manager;
    Transform items;
    float inventory_height;
    Messages messages;


    void Awake()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        items = transform.Find("View/Items");
        messages = GameObject.Find("/Canvas/GUI/Messages").GetComponent<Messages>();
        inventory_height = items.GetComponent<RectTransform>().sizeDelta.y;
        // Load items
        if (manager.GetSceneName() == "Level_2") {
            GameObject sand = Resources.Load("Prefabs/Level_2/Sand") as GameObject;
            AddItem(sand.GetComponent<Interactable>(), true);
        }
    }
    
    public void AddItem(Interactable interactable, bool mute = false)
    {
        GameObject obj = new GameObject(interactable.title);
        obj.transform.SetParent(items);
        
        Item item = obj.AddComponent(typeof(Item)) as Item;
        item.interactable = interactable;

        Image image = obj.AddComponent(typeof(Image)) as Image;
        image.sprite = interactable.GetImage();
        
        RectTransform rect = obj.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(inventory_height, inventory_height);
        rect.localScale = new Vector2(1, 1);

        obj.AddComponent<CanvasGroup>();

        // Show message
        messages.InventoryMessage();

        // Play sound
        if (!mute) {
            audio_source.PlayOneShot(item_sound);
        }
    }

    override protected void Init() {}
}
