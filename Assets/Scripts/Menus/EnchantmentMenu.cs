using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnchantmentMenu : Window
{
    
    public Sprite button_image;
    
    Interactable target;
    TMP_Text title;
    Image image;
    Transform buttons;
    MagicBook magic_book;
    Object button_prefab;
    
    void Awake()
    {
        title =         GameObject.Find("/Canvas/GUI/Menus/EnchantmentMenu/Left/Title").GetComponent<TMP_Text>();
        image =         GameObject.Find("/Canvas/GUI/Menus/EnchantmentMenu/Left/Image").GetComponent<Image>();
        buttons =       GameObject.Find("/Canvas/GUI/Menus/EnchantmentMenu/Buttons").transform;
        magic_book =    GameObject.Find("/Canvas/GUI/Menus/MagicBook").GetComponent<MagicBook>();
        button_prefab = Resources.Load("Prefabs/GUI/Button");
    }

    public void Open(Interactable interactable)
    {
        // Set target
        target = interactable;
        // Update display
        title.text = target.title;
        image.sprite = target.GetImage();
        // Delete old spell buttons
        foreach(Transform child in buttons) {
            Destroy(child.gameObject);
        }
        // Create spell buttons
        foreach(Word verb in magic_book.verbs) {
            GameObject obj = Instantiate(button_prefab, buttons) as GameObject;
            obj.name = verb.english;

            TMP_Text text = obj.transform.GetChild(0).GetComponent<TMP_Text>();
            text.text = verb.german;

            Button button = obj.GetComponent<Button>();
            button.onClick.AddListener(() => {
                target.Enchant(verb.english);
            });
        }
        
        // Open window
        Open();
    }
    
    override protected void Init() {}
}
