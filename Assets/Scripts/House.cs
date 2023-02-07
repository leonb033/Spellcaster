using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour, IDropHandler
{
    public Sprite door_open;
    
    public void OnDrop(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = door_open;
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Vocabulary", LoadSceneMode.Single);
    }
}
