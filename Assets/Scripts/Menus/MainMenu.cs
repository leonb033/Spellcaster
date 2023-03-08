using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Manager manager;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }
    
    public void NewGame()
    {
        manager.NewGame();
    }

    public void ContinueGame()
    {
        manager.LoadNextScene();
    }

    public void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }
}
