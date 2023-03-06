using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class House : Interactable
{
    public Sprite image_open;

    public void Open()
    {
        GetComponent<Image>().sprite = image_open;
        can_use = true;
    }

    public override void Use()
    {
        SceneManager.LoadScene("Level_2", LoadSceneMode.Single);
    }
}
