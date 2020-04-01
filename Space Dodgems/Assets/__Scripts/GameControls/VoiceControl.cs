using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

// adapted from https://www.youtube.com/watch?v=29vyEOgsW8s
public class VoiceControl : MonoBehaviour
{
    GameObject[] pauseObjects;

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start()
    {
        actions.Add("pause", PauseGame);
        actions.Add("pause game", PauseGame);
        actions.Add("stop", PauseGame);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;

        //starts listening
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void PauseGame()
    {
        Debug.Log("Pausing Game");
        Time.timeScale = 0;
    }
    
}
