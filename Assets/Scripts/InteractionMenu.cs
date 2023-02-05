using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionMenu : MonoBehaviour
{
    // InteractionMenu
    private TMP_Text text_name;
    private Image image_info;
    private TMP_Text text_description;
    private Button button_inspect;
    private Button button_use;
    private Button button_pickup;
    private Button button_enchant;

    void Start()
    {
        text_name =         transform.Find("Info/Text").GetComponent<TMP_Text>();
        image_info =        transform.Find("Info/Image").GetComponent<Image>();
        text_description =  transform.Find("Description/Viewport/Text").GetComponent<TMP_Text>();
        button_inspect =    transform.Find("Interaction/Inspect").GetComponent<Button>();
        button_use =        transform.Find("Interaction/Use").GetComponent<Button>();
        button_pickup =     transform.Find("Interaction/PickUp").GetComponent<Button>();
        button_enchant =    transform.Find("Interaction/Enchant").GetComponent<Button>();

        Close();
    }

    public void UpdateMenu(Interactable interactable)
    {
        // Update menu fields
        text_name.text = interactable.title;
        image_info.sprite = interactable.image;
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
        button_inspect.onClick.AddListener(() => interactable.Inspect());
        button_use.onClick.AddListener(() => interactable.Use());
        button_pickup.onClick.AddListener(() => interactable.PickUp());
        button_enchant.onClick.AddListener(() => interactable.Enchant());
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        // Hide menu
        gameObject.SetActive(false);
    }
}
