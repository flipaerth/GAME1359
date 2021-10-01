using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField, Header("Player Parameters")]

    // Public Variable for movement speed - adjusted in editor - set to 1 by default
    public float playerSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
         Input Variables
         */

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Gets Unity's left and right input/horizontal input and saves into a float.  *
         * Axis gets left & right, -1 is left, 1 is right, 0 is nothing                *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        float h = Input.GetAxis("Horizontal");

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Gets Unity's up and down input/vertical input and saves into a float.       *
         * Axis gets up & down, -1 is down, 1 is up, 0 is nothing                      *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        float v = Input.GetAxis("Vertical");

        /*
         Movement
         */
        // Time.deltaTime = converts to real time, rather than based on every frame
        transform.position = new Vector3(transform.position.x + h * Time.deltaTime * playerSpeed,
                                         transform.position.y,
                                         transform.position.z + v * Time.deltaTime * playerSpeed);
    }
}
