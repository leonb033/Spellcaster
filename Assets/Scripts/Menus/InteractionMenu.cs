using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionMenu : Window
{
    // InteractionMenu
    private TMP_Text text_name;
    private Image image_info;
    private TMP_Text text_description;
    private Button button_inspect;
    private Button button_use;
    private Button button_pickup;
    private Button button_enchant;

    void Awake()
    {
        text_name =         transform.Find("/Canvas/GUI/Menus/InteractionMenu/Info/Text").GetComponent<TMP_Text>();
        image_info =        transform.Find("/Canvas/GUI/Menus/InteractionMenu/Info/ImageContainer/Image").GetComponent<Image>();
        text_description =  transform.Find("/Canvas/GUI/Menus/InteractionMenu/Description/Viewport/Text").GetComponent<TMP_Text>();
        button_inspect =    transform.Find("/Canvas/GUI/Menus/InteractionMenu/Interaction/Inspect").GetComponent<Button>();
        button_use =        transform.Find("/Canvas/GUI/Menus/InteractionMenu/Interaction/Use").GetComponent<Button>();
        button_pickup =     transform.Find("/Canvas/GUI/Menus/InteractionMenu/Interaction/PickUp").GetComponent<Button>();
        button_enchant =    transform.Find("/Canvas/GUI/Menus/InteractionMenu/Interaction/Enchant").GetComponent<Button>();
    }

    public void UpdateMenu(Interactable interactable)
    {
        print("UpdateMenu");
        print(interactable);
        // Update menu fields
        text_name.text = interactable.title;
        image_info.sprite = interactable.GetImage();
        text_description.text = interactable.description;
        // Enable / disable interaction buttons
        button_inspect.interactable = interactable.can_inspect;
        button_use.interactable = interactable.can_use;
        button_pickup.interactable = interactable.can_pickup;
        button_enchant.interactable = interactable.can_enchant;
        // Remove previous actions
        button_inspect.onClick.RemoveAllListeners();
        button_use.onClick.RemoveAllListeners();
        button_pickup.onClick.RemoveAllListeners();
        // Update interaction button actions
        if (interactable.can_inspect) {
            button_inspect.onClick.AddListener(() => interactable.Inspect());
        }
        if (interactable.can_use) {
            button_use.onClick.AddListener(() => interactable.Use());
        }
        if (interactable.can_pickup) {
            button_pickup.onClick.AddListener(() => interactable.PickUp());
        }
        if (interactable.can_enchant) {
            button_enchant.onClick.AddListener(() => interactable.OpenInEnchantmentMenu());
        }
    }

    override protected void Init() {}
}
