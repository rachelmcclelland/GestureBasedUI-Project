using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public Camera mainCamera;

    private Vector2 screenBounds;
    private float objectWidth;

    void Start()
    {
        // define screen bounds
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                                                             mainCamera.transform.position.z));

        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        // objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;

        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth,
                                        screenBounds.x - objectWidth);
        transform.position = viewPos;


    }
}
