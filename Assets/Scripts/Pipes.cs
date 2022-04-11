using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 5f; // used for pipe movement

    private float leftEdge; // used for destroying pipes

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // sets screen camera values to left edge
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // moves pipes

        if(transform.position.x < leftEdge) // if pipes are off screen, then it destroys game objects.
        {
            Destroy(gameObject); // destroys game objects
        }
    }
}



