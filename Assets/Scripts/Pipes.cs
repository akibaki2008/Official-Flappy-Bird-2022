using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float limit = 5f;

    public float speed = 5f; // used for pipe movement

    private float leftEdge; // used for destroying pipes

    private void Start()
    {
        Transform top = transform.GetChild(0 );
        Transform bottom = transform.GetChild(1);
        float offset = Random.Range(-1,2); 

        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // sets screen camera values to left edge

        float b = FindObjectOfType<Game_Manager>().timeElaspsed;
        if (b > limit)
        {
            b = limit;
        }


        top.position = new Vector3(8,5-b + offset);
        bottom.position = new Vector3(8, -5 +b + offset);



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



