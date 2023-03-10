using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Interactable
{   
    Manager manager;
    
    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }
    
    public override void Use()
    {
        manager.LoadScene("End");
    }
}
