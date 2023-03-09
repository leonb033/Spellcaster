using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public AudioClip sound_open;
    public AudioClip sound_close;

    protected AudioManager audio_manager;
    
    void Start()
    {
        audio_manager = GameObject.Find("/Manager").GetComponent<AudioManager>();
        Init();
        Close();
    }

    protected abstract void Init();

    public void Open()
    {
        // Close all other windows
        foreach (var window in FindObjectsOfType<Window>())
        {
            window.Close();
        }
        // Enable window
        gameObject.SetActive(true);
        // Play sound
        if (sound_open) {
            audio_manager.Play(sound_open);
        }
    }
    
    public void Close()
    {
        // Play sound
        if (sound_close && (Time.time > 1.0)) {
            audio_manager.Play(sound_close);
        }
        // Disable window
        gameObject.SetActive(false);
    }

    public void Toggle()
    {
        if (!gameObject.activeSelf) {
            Open();
        }
        else {
            Close();
        }
    }
}
