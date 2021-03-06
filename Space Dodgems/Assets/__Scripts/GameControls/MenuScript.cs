﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

// adpated from https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
public class MenuScript : MonoBehaviour
{
    GameObject[] pauseObjects;

    // used for speech recognition
    private KeywordRecognizer keywordRecognizer;

    // contains the string the speech can say and the function that 
    // will be called when a certain word is said
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();

        // what the user can say to control the game
        actions.Add("play", pauseControl);
        actions.Add("resume", pauseControl);
        actions.Add("reload", Reload);
        actions.Add("restart", Reload);
        actions.Add("main menu", LoadMain);

        // set the KeywordRecognizer
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        // called when a phrase in the dictionary is recognised
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        //starts listening
        keywordRecognizer.Start();
 
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        // Debug.Log(speech.text);

        // invoke a method depending on what is said
        // speech.text = string that is recognised
        actions[speech.text].Invoke();
    }

    void Update()
    {
        // if the game is paused, show the paused menu 
        if (Time.timeScale == 0)
        {
            showPaused();
        }
        
    }

    // reload the current scene back to the start
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }

    }

    // load the main menu level
    private void LoadMain()
    {
        Application.LoadLevel("Menu");
    }
}
