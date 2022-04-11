using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 direction;

    private SpriteRenderer spriteRenderer; // gets refernce to sprite renderer

    public float gravity = -9.8f; // public lets it show up in editor

    public float strength = 5f;

    public Sprite[] sprites; // makes array of sprites to cycle between

    private int spriteIndex; // keeps track of current index in array

    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // gets component from spriteRenderer and sets it to spriteRenderer variable

    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f ,0.15f );
        // a way of calling another function, and repeating
    }


    private void Update()

    
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) 
        {
            direction = Vector3.up*strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began) // if touching has begun then do stuff
            {
                direction = Vector3.up * strength;
            }

        }


        direction.y += gravity * Time.deltaTime; // gravity set to variable direction
        transform.position += direction * Time.deltaTime ;  // direction variable sets transform.position for player


    }


    private void AnimateSprite()
    {
        spriteIndex++; // increments through sprite Index by one
        if (spriteIndex >= sprites.Length) // if reached end of index
        {
            spriteIndex = 0; // sets it to zero to loop between sprites
        }

        spriteRenderer.sprite = sprites[spriteIndex]; // sets sprite to it
    }



    private void OnTriggerEnter2D(Collider2D collision) // allows collision mechanics
    {
        if (gameObject.tag == "Obstacle")
        {
            FindObjectOfType<Game_Manager>().GameOver();
        }
        else if (gameObject.tag == " Scoring")
        {
            FindObjectOfType<Game_Manager>().IncreaseScore();
        }
    }
}
