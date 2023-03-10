using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // Manager is available in all scenes

    bool intro_done = false;
    List<string> scene_history = new List<string>();

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

    public string GetSceneFromHistory(int i)
    {
        if (i >= 0) {
            return scene_history[i];
        }
        else {
            return scene_history[scene_history.Count + i];
        }
    }

    public void LoadScene(string scene, bool add = false)
    {
        if ((GetSceneName() != "Vocabulary") && (GetSceneName() != "VocabularyResults")) {
            scene_history.Add(GetSceneName());
        }
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
            if (GetSceneFromHistory(-1).StartsWith("Level_")) {
                IncreaseLevelId();
                LoadScene("Story");
            }
            else {
                LoadScene("MainMenu");
            }
        }
    }

    public void NewGame()
    {
        SetLevelId(1);
        LoadNextScene();
    }
}
