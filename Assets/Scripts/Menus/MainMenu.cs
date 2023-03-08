using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Manager manager;
    Button continue_button;

    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
        if (manager.GetLevelId() > 1) {
            continue_button.interactable = true;
        }
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
