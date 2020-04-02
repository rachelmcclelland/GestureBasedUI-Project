using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private AudioSource audioSource;
    public static bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MuteSound();

        }

    }

    // method to play a clip once
    public void PlayOneShot(AudioClip clip)
    {
        if (clip)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public static SoundController FindSoundController()
    {
        var soundController = FindObjectOfType<SoundController>();

        if (!soundController)
        {
            Debug.Log("Sound not found! No sound will play");
        }

        return soundController;
    }

    public void MuteSound()
    {
        if (muted)
        {
            AudioListener.pause = false;
            muted = false;
        }
        else
        {
            AudioListener.pause = true;
            muted = true;
        }
    }

}
