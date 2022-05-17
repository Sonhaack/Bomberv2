using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Settings : MonoBehaviour
{
    public AudioManager audioManager;
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioManager.sounds[1].audioSource.volume = volume;
        audioManager.sounds[2].audioSource.volume = volume;
    }
    
    public void SetMusic(float volume)
    {
        Debug.Log(volume);
        audioManager.sounds[0].audioSource.volume = volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
}
