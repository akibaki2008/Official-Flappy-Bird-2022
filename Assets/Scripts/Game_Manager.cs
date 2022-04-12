using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{


    public float timeElaspsed = 0f;

    public int score = 0; // public so we can access it in player.cs

    public void GameOver() // public so we can access it in player.cs
    {
        Debug.Log("Game Over");
    }

    public void Update()
    {
        timeElaspsed += Time.deltaTime;
    }



    public void IncreaseScore()
    {
        score++;
    }
}
