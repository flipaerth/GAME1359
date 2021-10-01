using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Editor Variables
    [SerializeField, Header("Player Speed")]
    public float playerSpeed = 1; // Public Variable for movement speed - adjusted in editor - set to 1 by default
    //public float jumpForce = 1;   // Player Jump - makes it as an editable variable within Unity editor - set to 1 by default

    // Create an object of Rigidbody
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigid body currently attached to the object (in this instance, the player)
        rb = GetComponent<Rigidbody>();
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

        // Examples of Movement
        // Time.deltaTime = converts to real time, rather than based on every frame
        //******************************************************************************************************************************
        //******************************************************************************************************************************
        // transform.position = new Vector3(transform.position.x + h * Time.deltaTime * playerSpeed,
        //                                 transform.position.y,
        //                                 transform.position.z + v * Time.deltaTime * playerSpeed);
        //******************************************************************************************************************************
        //******************************************************************************************************************************
        // transform.Translate will take a vector, and move the object along that vector
        // Move the transform in the direction in distance - translation being the vector
        // transform.Translate(transform.forward * Time.deltaTime * playerSpeed * v); // move forward at a rate * speed * the input (v)
        //******************************************************************************************************************************
        //******************************************************************************************************************************

        rb.velocity = new Vector3(h * playerSpeed,  // X Axis - changes velocity
                                  rb.velocity.y,    // Y Axis - sets to current velocity
                                  v * playerSpeed); // Z Axis - changes velocity

        //******************************************************************************************************************************
        //******************************************************************************************************************************
        // Player Jump
        /*
        if (Input.GetButtonDown("Jump"))
        {
            // Function to call the jump
            Jump();
        }
        */
    }

    /*
    public void Jump()
    {
        // Sets the velocity to a new Vector3 - does the opposite of the moving
        rb.velocity = new Vector3(rb.velocity.x,  // X Axis
                                  jumpForce,      // Y Aixs
                                  rb.velocity.z); // Z Axis
    }
    */
}
