using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);           // Load the next scene in the q
    }

    public void QuitGame()
    {
        print("QUIT");
        //Application.Quit();
        SceneManager.LoadScene("Start");
    }
}
