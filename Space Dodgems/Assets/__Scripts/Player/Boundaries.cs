using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var LeftSide = collision.GetComponent<PlayerController>(); // hit by player

        if (LeftSide)
        {
            Debug.Log("Here");
            //PublishEnemyKilledEvent();
            //SceneManager.LoadScene("GameOver"); // load game over page
            Vector3 viewPos = transform.position;

            viewPos.x = Mathf.Clamp(viewPos.x, -4, -10);
            transform.position = viewPos;
        }   

    }
}
