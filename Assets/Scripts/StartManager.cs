using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKey)
        {
            print("Any key was pressed");
            SceneManager.LoadScene("MainMenu");
        }
    }
}
