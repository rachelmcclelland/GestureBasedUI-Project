using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);

        if(Input.GetKey (KeyCode.RightArrow)) {
            player.GetComponent<Rigidbody>().velocity = new Vector3(7f, -7f, 0f);
        }
        else if(Input.GetKey (KeyCode.LeftArrow)) {
            player.GetComponent<Rigidbody>().velocity = new Vector3(-7f, 0f, 0f);
        }
        
    }
}
