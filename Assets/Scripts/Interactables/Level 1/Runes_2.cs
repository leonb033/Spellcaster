using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runes_2 : Interactable
{
    MagicBook magic_book;
    
    void Start()
    {
        magic_book = GameObject.Find("/Canvas/GUI/Menus/MagicBook").GetComponent<MagicBook>();
    }
    
    public override void Inspect()
    {
        magic_book.AddVerb(new Word("shrink", "verkleinern"));
        can_inspect = false;
        UpdateMenu();
    }
}
