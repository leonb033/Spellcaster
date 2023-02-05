using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VocabularyMenu : MonoBehaviour
{
    public void BackToLections()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Lection1()
    {
        SceneManager.LoadScene("Vocabulary");
        // with gameobject Lection1 enabled, other disabled
    }
}
