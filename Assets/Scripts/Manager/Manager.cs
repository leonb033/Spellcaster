using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Manager is available in all scenes

    bool intro_done = false;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetLevelId()
    {
        if (!intro_done) {
            return 0;
        }
        else {
            return PlayerPrefs.GetInt("level");
        }
    }

    public void SetLevelId(int id)
    {
        PlayerPrefs.SetInt("level", id);
    }

    public void IncreaseLevelId()
    {
        SetLevelId(GetLevelId() + 1);
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string scene, bool add = false)
    {
        LoadSceneMode mode = LoadSceneMode.Single;
        if (add) {
            mode = LoadSceneMode.Additive;
        }
        SceneManager.LoadScene(scene, mode);
    }

    public void LoadNextScene()
    {
        if ((GetSceneName() == "Start")) {
            LoadScene("Story");
        }
        else if ((GetSceneName() == "Story") && !intro_done) {
            intro_done = true;
            LoadScene("MainMenu");
        }
        else if (GetSceneName() == "MainMenu") {
            LoadScene("Story");
        }
        else if ((GetSceneName() == "Story") && intro_done) {
            LoadScene("Level_"+GetLevelId());
        }
        else if (GetSceneName().StartsWith("Level")) {
            LoadScene("Vocabulary");
        }
        else if (GetSceneName() == "VocabularyResults") {
            IncreaseLevelId();
            LoadScene("Story");
        }
    }

    public void NewGame()
    {
        SetLevelId(1);
        LoadNextScene();
    }
}
