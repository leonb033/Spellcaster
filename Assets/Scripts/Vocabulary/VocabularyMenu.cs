using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VocabularyMenu : MonoBehaviour
{
    Manager manager;
    GameObject voc_manager;

    void Start()
    {
        voc_manager = GameObject.Find("/Vocabulary Manager");
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }

    public void BackToLections()
    {
        Destroy(voc_manager);
        manager.LoadScene("MainMenu");
    }

    public void Lection1()
    {
        manager.LoadScene("Vocabulary");
    }

     
}
