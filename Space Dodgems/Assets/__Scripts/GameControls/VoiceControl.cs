using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq; // used for .toArray()

// adapted from https://www.youtube.com/watch?v=29vyEOgsW8s
public class VoiceControl : MonoBehaviour
{
    GameObject[] pauseObjects;

    // used for speech recognition
    private KeywordRecognizer keywordRecognizer;

    // contains the string the speech can say and the function that 
    // will be called when a certain word is said
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        // add the strings and associated methods
        actions.Add("pause", PauseGame);
        actions.Add("pause game", PauseGame);
        actions.Add("stop", PauseGame);

        // set the KeywordRecognizer
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        // called when a phrase in the dictionary is recognised
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        //starts listening
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        //Debug.Log(speech.text);

        // invoke a method depending on what is said
        // speech.text = string that is recognised
        actions[speech.text].Invoke();
    }

    private void PauseGame()
    {
        //Debug.Log("Pausing Game");
        Time.timeScale = 0;
    }
    
}
