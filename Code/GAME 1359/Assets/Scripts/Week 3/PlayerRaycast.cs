using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField]
    public bool canJump = false;
    [SerializeField, Header("Player Jump Force")]
    public float jumpForce = 1;   // Player Jump - makes it as an editable variable within Unity editor - set to 1 by default

    // Create an object of Rigidbody
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a Ray
        // First parameter is an origin, the second is a direction - they're both vectors - a vector is a point in space
        // Ray r = new Ray();

        Ray r = new Ray(transform.position, Vector3.down);
        // transform.position - the objects position
        // Vector3.down - angle pointing downwards
        // ^^ transform.forward - points forward


        // Draw a ray to show the ray - shows in scene view
        Debug.DrawRay(r.origin, r.direction);


        // Gives more control over the distance of the line
        Debug.DrawLine(r.origin, r.origin + (Vector3.down * 1));
        // takes in a start and an end point

        // Figure out what the ray cast hits
        RaycastHit hit;

        // pass in the ray (r), pass out the hit, and 1 is the distance
        if (Physics.Raycast(r, out hit, 1))
        {
            if (hit.transform != null)
            {
                canJump = true;
                Debug.Log(hit.transform.name);
            }
        }
        else
        {
            canJump = false;
        }

        if (canJump == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                // Function to call the jump
                Jump();
            }
        }
    }

    public void Jump()
    {
        // Sets the velocity to a new Vector3 - does the opposite of the moving
        rb.velocity = new Vector3(rb.velocity.x,  // X Axis
                                  jumpForce,      // Y Aixs
                                  rb.velocity.z); // Z Axis
    }
}
