using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Create the Game Manager
    public static GameManager instance;
    public int coins = 0;
    public int coinsRemaining = 4;

    // Start is called before the first frame update
    void Start()
    {
        // Attached GameManager script to game object Manager if the instance is empty
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // Destroys the game object if one already exists
            Destroy(gameObject);
        }

        // Doesn't destroy the game object when loading a new scene
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
