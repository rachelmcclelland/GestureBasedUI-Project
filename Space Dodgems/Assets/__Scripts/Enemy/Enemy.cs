using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Enemy : MonoBehaviour
{

    // notify the system when it dies.
    public delegate void EnemyKilled(Enemy enemy);

    public static EnemyKilled EnemyKilledEvent;

   void Start()
    {
    }

    void Update()
    {
        // destroy enemy objects when they dissppear of the screen
        if(!GetComponent<Renderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }

        // gets kicked off when transform gets hit by something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>(); // hit by player

        if (player)
        {
            Debug.Log("Here");
            PublishEnemyKilledEvent();
            Time.timeScale = 0;
            //SceneManager.LoadScene("GameOver"); // load game over page
            
        }   

    }

        // event for the system
    private void PublishEnemyKilledEvent()
    {
        // EnemyKilledEvent?.Invoke(this);
        if (EnemyKilledEvent != null)
        {
            EnemyKilledEvent(this);
        }
    }
}
