using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueChange : MonoBehaviour
{
    //Reference to Audio Source Component
    private AudioSource audioSrc;

    //Music volume will be modified by dragging slider knob
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Setting the volume option of Audio source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    //This method takes volume value passed by slider and sets it as musicvalue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
