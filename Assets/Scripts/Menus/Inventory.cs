using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Window
{
    public AudioClip item_sound;
    
    Transform items;
    float inventory_height;
    Messages messages;

    void Awake()
    {
        items = transform.Find("View/Items");
        messages = GameObject.Find("/Canvas/GUI/Messages").GetComponent<Messages>();
        inventory_height = items.GetComponent<RectTransform>().sizeDelta.y;
    }
    
    public void AddItem(Interactable interactable)
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
        audio_source.PlayOneShot(item_sound);
    }

    override protected void Init() {}
}
