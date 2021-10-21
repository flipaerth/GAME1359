using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Create the Game Manager
    public static GameManager instance;

    [SerializeField, Header("Player Ammo")]
    public int ammo = 50;
    [SerializeField, Header("Player Health")]
    public float playerHP = 100;

    [SerializeField, Header("Target Info")]
    public int targetsHit = 0;
    public int totalTargets = 3;
    public int targetsRemaining;


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
        targetsRemaining = totalTargets - targetsHit;
    }
}
