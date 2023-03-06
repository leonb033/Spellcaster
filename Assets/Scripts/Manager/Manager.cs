using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Manager is available in all scenes
    // Children of manager are permanent
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
}
