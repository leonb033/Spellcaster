using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    AudioSource audio_source;

    void Start()
    {
        audio_source = GameObject.Find("/Manager/AudioSource").GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneChange;
    }

    void OnSceneChange(Scene scene, LoadSceneMode sceneMode)
    {
        StartCoroutine(Unmute());
    }

    IEnumerator Unmute()
    {
        audio_source.mute = true;
        yield return new WaitForSeconds(1.5f);
        audio_source.mute = false;
    }

    public void Play(AudioClip clip, float volume = 1.0f)
    {
        audio_source.PlayOneShot(clip, volume);
    }

    public void Play(string path, float volume = 1.0f)
    {
        if (Time.time < 0.1f) return;
        AudioClip clip = Resources.Load("Sounds/"+name) as AudioClip;
        audio_source.PlayOneShot(clip, volume);
    }
}
