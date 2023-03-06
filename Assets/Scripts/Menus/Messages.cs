using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour
{
    GameObject inventory_message;
    GameObject magicbook_message;

    void Awake()
    {
        inventory_message = GameObject.Find("/Canvas/GUI/Messages/Inventory");
        magicbook_message = GameObject.Find("/Canvas/GUI/Messages/MagicBook");
    }
    
    void Start()
    {
        inventory_message.SetActive(false);
        magicbook_message.SetActive(false);
    }

    public void InventoryMessage()
    {
        StartCoroutine(ShowMessage(inventory_message, 4.0f));
    }

    public void MagicBookMessage()
    {
        StartCoroutine(ShowMessage(magicbook_message, 4.0f));
    }

    IEnumerator ShowMessage(GameObject obj, float time)
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}
