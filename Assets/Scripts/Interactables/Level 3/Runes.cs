using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runes : Interactable
{
    MagicBook magic_book;
    
    void Start()
    {
        magic_book = GameObject.Find("/Canvas/GUI/Menus/MagicBook").GetComponent<MagicBook>();
    }
    
    public override void Inspect()
    {
        magic_book.AddVerb(new Word("ignite", "anzünden"));
        can_inspect = false;
        UpdateMenu();
    }
}
