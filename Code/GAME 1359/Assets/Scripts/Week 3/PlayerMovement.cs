using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

        // Horizontal Axis
        float h = Input.GetAxis("Horizontal");
        // Vertical Axis
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
