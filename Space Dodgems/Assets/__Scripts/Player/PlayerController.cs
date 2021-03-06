﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // get a change in direction
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //calculate a new x position
        var newXPos = transform.position.x + deltaX;

        transform.position = new Vector3(newXPos, transform.position.y, -5);
    }
    void OnCollisonEnter (Collision hit){

        Vector3 viewPos = transform.position;

        if(hit.gameObject.name == "LeftBounds"){

            float speedInXDirection = 0f;

            if(viewPos.x < 0f)
            {
                viewPos.x = 0;
            }
            
            transform.position = viewPos;

        }
        
    }
    
}
