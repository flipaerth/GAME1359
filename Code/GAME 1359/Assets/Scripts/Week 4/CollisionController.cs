using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Debug.Log("Collided with coin.");
            Destroy(collision.gameObject);
            Debug.Log("Coin destroyed.");
            GameManager.instance.coins++;
            GameManager.instance.coinsRemaining--;
        }

        // Restart the game by collecting the final coin
        if (collision.gameObject.tag == "PlayAgain")
        {
            Debug.Log("Collided with play again coin.");
            Destroy(collision.gameObject);
            Debug.Log("Play again coin destroyed.");
            SceneManager.LoadScene(0);
            Debug.Log("Loaded first scene.");
            GameManager.instance.coins = 0;
            GameManager.instance.coinsRemaining = 4;
            Debug.Log("Scoreboard reset.");
        }

        // If the total amount of coins are collected, move to the next scene
        if (GameManager.instance.coinsRemaining == 0)
        {
            GameManager.instance.coinsRemaining = 4;
            SceneManager.LoadScene(1);
        }

        // Restart the scene if the player hits the death zone
        if (collision.gameObject.tag == "DeathZone")
        {
            GameManager.instance.coins = 0;
            GameManager.instance.coinsRemaining = 4;
            SceneManager.LoadScene(0);
        }
    }
}
