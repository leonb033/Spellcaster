using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    Manager manager;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();       
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        manager.LoadScene("MainMenu");
    }
}
