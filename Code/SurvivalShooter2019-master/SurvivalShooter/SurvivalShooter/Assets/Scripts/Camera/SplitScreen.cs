using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    [SerializeField, Header("Player One Camera")]
    public Camera cam1;
    [SerializeField, Header("Player Two Camera")]
    public Camera cam2;

    [SerializeField, Header("Player Two Prefab")]
    public Transform playerTwo;

    [SerializeField, Header("Player Two Camera Prefab")]
    public Transform playerTwoCamera;

    public static bool splitScreenBool = false;
    public PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            splitScreenBool = true;
            Instantiate(playerTwoCamera, new Vector3(5, 15, -22), Quaternion.Euler(30f, 0, 0));
            Instantiate(playerTwo, new Vector3(4, 0, 0), Quaternion.identity);
            cam1.rect = new Rect(0, 0.5f, 1, 0.5f);
            cam2.rect = new Rect(0, 0, 1, 0.5f);
        }
        if (playerHealth.currentHealth <= 0)
        {
            splitScreenBool = false;
        }
    }
}
