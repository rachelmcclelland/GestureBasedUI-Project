using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBehaviour : MonoBehaviour
{
    // == private fields ==
    [SerializeField]
    private float speed;

    Scene currentScene;
    string sceneName;

    private Rigidbody2D rb; //rigid body component

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;

        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }

}
