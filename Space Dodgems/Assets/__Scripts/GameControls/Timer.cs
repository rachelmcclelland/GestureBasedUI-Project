using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    Scene currentScene;
    string sceneName;
    float timer;
    public static float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
    }

     void Update()
    {
        StopWatchTimer();
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeStart);
        timer += Time.deltaTime;

        if (sceneName == "SpaceDodgems")
        {
            if ((int)timer == 20)
            {
                SceneManager.LoadScene("SpaceDodgemsLevel2");
            }
        }

    }
    void StopWatchTimer()
    {
        timeStart += Time.deltaTime;
    }
}
