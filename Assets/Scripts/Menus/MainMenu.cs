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
        continue_button = GameObject.Find("/Canvas/Main Menu/Continue Button").GetComponent<Button>();
        if (manager.GetLevelId() > 1) {
            continue_button.interactable = true;
        }
        print(manager.GetLevelId());
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
