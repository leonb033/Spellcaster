using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionMenu : MonoBehaviour
{
    // InteractionMenu
    private GameObject interaction_menu;
    private TMP_Text text_name;
    private Image image_info;
    private TMP_Text text_description;
    private Button button_inspect;
    private Button button_use;
    private Button button_pickup;

    void Start()
    {
        interaction_menu =  GameObject.Find("/Canvas/InteractionMenu");
        text_name =         interaction_menu.transform.Find("Info/Text").GetComponent<TMP_Text>();
        image_info =        interaction_menu.transform.Find("Info/Image").GetComponent<Image>();
        text_description =  interaction_menu.transform.Find("Description/Viewport/Text").GetComponent<TMP_Text>();
        button_inspect =    interaction_menu.transform.Find("Interaction/Inspect").GetComponent<Button>();
        button_use =        interaction_menu.transform.Find("Interaction/Use").GetComponent<Button>();
        button_pickup =     interaction_menu.transform.Find("Interaction/PickUp").GetComponent<Button>();

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
        // Remove previous actions
        button_inspect.onClick.RemoveAllListeners();
        button_use.onClick.RemoveAllListeners();
        button_pickup.onClick.RemoveAllListeners();
        // Update interaction button actions
        button_inspect.onClick.AddListener(() => interactable.Inspect());
        button_use.onClick.AddListener(() => interactable.Use());
        button_pickup.onClick.AddListener(() => interactable.PickUp());
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        // Remove previous button actions
        button_inspect.onClick.Invoke();
        button_use.onClick.Invoke();
        button_pickup.onClick.Invoke();
        // Hide menu
        gameObject.SetActive(false);
    }
}
