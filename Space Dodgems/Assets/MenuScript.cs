using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adpated from https://www.sitepoint.com/adding-pause-main-menu-and-game-over-screens-in-unity/
public class MenuScript : MonoBehaviour
{
    GameObject[] pauseObjects;

    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
    }

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
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
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

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }

}
