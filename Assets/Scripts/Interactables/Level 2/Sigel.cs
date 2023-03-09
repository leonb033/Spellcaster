using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigel : Interactable
{
    public string letter;
    public GameObject door;
    
    public override void Combine(Item item)
    {
        if (item.interactable.title.EndsWith(letter))
        {
            door.GetComponent<Door>().RemoveSeal(letter);
            Destroy(item.gameObject);
            Destroy(this.gameObject);
        }
    }
}
