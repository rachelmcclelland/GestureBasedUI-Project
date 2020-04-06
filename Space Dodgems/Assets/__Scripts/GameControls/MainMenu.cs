using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        // what the user can say to control the game
        actions.Add("start", PlayGame);
        actions.Add("play game", PlayGame);
        actions.Add("play", PlayGame);
        actions.Add("quit", QuitGame);
        actions.Add("leave", QuitGame);
        actions.Add("end game", QuitGame);

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

    public void PlayGame ()
    {
        SceneManager.LoadScene("SpaceDodgems");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
