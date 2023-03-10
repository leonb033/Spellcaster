using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyMenu : MonoBehaviour
{
    Manager manager;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }

    public void BackToLections()
    {
        manager.LoadScene("MainMenu");
    }

    public void Lection1()
    {
        manager.LoadScene("Vocabulary");
    }

     
}
