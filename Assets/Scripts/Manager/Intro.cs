using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    Manager manager;
    Button button;
    
    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        button = GameObject.Find("/Canvas/GUI/Continue").GetComponent<Button>();
        button.onClick.AddListener(() => {
            manager.LoadScene("MainMenu");
        });
    }
}
