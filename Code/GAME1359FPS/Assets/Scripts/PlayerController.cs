using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Editor Variables
    [SerializeField, Header("Player Speed")]
    public float playerSpeed = 1; // Public Variable for movement speed - adjusted in editor - set to 1 by default
    [SerializeField, Header("Player Jump Force")]
    public float jumpForce = 1;   // Player Jump - makes it as an editable variable within Unity editor - set to 1 by default
    [SerializeField, Header("Player Jump Bool")]
    public bool canJump = false;  // Bool to determine if the player can jump or not
    [SerializeField]
    Transform cam; // Reference to the camera

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

        // Which way the camera is looking
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        // Normalize grabs the direction - grabs the unit vector, not the length
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * playerSpeed) + (camRight * h * playerSpeed);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);

        // Create a Ray
        Ray r = new Ray(transform.position, Vector3.down);

        // Draw a ray to show the ray - shows in scene view
        Debug.DrawRay(r.origin, r.direction);

        // Gives more control over the distance of the line
        Debug.DrawLine(r.origin, r.origin + (Vector3.down * 1));

        // Figure out what the ray cast hits
        RaycastHit hit;

        // pass in the ray (r), pass out the hit, and 1 is the distance
        if (Physics.Raycast(r, out hit, 1))
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);
            }
            if (hit.transform.name == "Ground")
            {
                canJump = true;
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
                Debug.Log("Player Jumped");
                // Function to call the jump
                Jump();
            }
        }

        // If the player's hp reaches 0, leads game over and resets variables
        if (GameManager.instance.playerHP <= 0)
        {
            SceneManager.LoadScene(2);
            GameManager.instance.playerHP = 100;
            GameManager.instance.ammo = 50;
        }

        // If the player hits all of the targets, leads to victory screen and resets variables
        if (GameManager.instance.targetsRemaining == 0 && GameManager.instance.targetsHit == 3)
        {
            Debug.Log("Player Hit All Targets");
            SceneManager.LoadScene(3);
            GameManager.instance.playerHP = 100;
            GameManager.instance.ammo = 50;
            GameManager.instance.targetsHit = 0;
            GameManager.instance.targetsRemaining = GameManager.instance.totalTargets;
        }
    }

    public void Jump()
    {
        // Sets the velocity to a new Vector3 - does the opposite of the moving
        rb.velocity = new Vector3(rb.velocity.x,  // X Axis
                                  jumpForce,      // Y Aixs
                                  rb.velocity.z); // Z Axis
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player collects an ammo pack
        if (other.gameObject.tag == "Ammo")
        {
            Debug.Log("Player Picked Up Ammo Pack");
            GameManager.instance.ammo += 50;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the player goes out of bounds
        if (collision.gameObject.tag == "KillZone")
        {
            Debug.Log("Player Fell Into Kill Zone");
            SceneManager.LoadScene(2);
            GameManager.instance.playerHP = 100;
            GameManager.instance.ammo = 50;
        }
    }

}
