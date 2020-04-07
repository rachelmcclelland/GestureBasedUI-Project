using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

// adpated from https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
public class GameOverScript : MonoBehaviour
{
    // used for speech recognition
    private KeywordRecognizer keywordRecognizer;

    // contains the string the speech can say and the function that 
    // will be called when a certain word is said
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        // what the user can say to control the game
        actions.Add("play", PlayGame);
        actions.Add("play again", PlayGame);
        actions.Add("quit", QuitGame);
        actions.Add("end game ", QuitGame);

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

    //controls the pausing of the scene
    public void PlayGame()
    {
        SceneManager.LoadScene("SpaceDodgems");
    }
   
    private void QuitGame()
    {
        Application.Quit();
    }
}
