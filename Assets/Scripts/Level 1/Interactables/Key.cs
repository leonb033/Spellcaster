using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    
    public override void Combine(Item item)
    {
        print(rect.localScale);
        switch(item.interactable.title) 
        {
            case "Stock":
                if (rect.localScale == new Vector3(0.5f, 0.5f, 0.0f)) {
                    PickUp();
                }
                break;
        }
    }

    public override void Enchant(string spell)
    {
        switch(spell) 
        {
            case "shrink":
                rect.localScale = new Vector2(0.5f, 0.5f);
                break;
            case "grow":
                rect.localScale = new Vector2(2.0f, 2.0f);
                break;
        }
    }
}
