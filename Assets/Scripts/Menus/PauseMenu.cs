using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Window
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }    

    override protected void Init() {}
}
