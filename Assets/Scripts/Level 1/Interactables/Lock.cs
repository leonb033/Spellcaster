using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : Interactable
{
    public GameObject house;

    public override void Combine(Item item)
    {
        switch(item.interactable.title) 
        {
            case "Schlüssel":
                house.GetComponent<House>().Open();
                Destroy(gameObject);
                break;
        }
    }
}
