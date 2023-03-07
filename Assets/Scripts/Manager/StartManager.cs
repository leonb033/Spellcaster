using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    Manager manager;
    
    void Start()
    {
        manager = GameObject.Find("/Manager").GetComponent<Manager>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            manager.LoadNextScene();
        }
    }
}
