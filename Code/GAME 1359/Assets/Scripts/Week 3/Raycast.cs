using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

        // pass in the ray (r), pass out the hit, and 10 is the distance
        if (Physics.Raycast(r, out hit, 1))
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
