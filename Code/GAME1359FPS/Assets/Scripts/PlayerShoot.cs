using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField, Header ("Bullet Reference")]
    GameObject bullet;

    [SerializeField, Header("Bullet Speed")]
    float bulletSpeed;

    [SerializeField, Header("Camera Reference")]
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.instance.ammo > 0)
            {
                GameManager.instance.ammo--;

                // The direction the bullet will travel
                // Whatever direction the camera is facing, that's considered forward for the bullet
                Vector3 bulletDirection = GetComponentInChildren<Camera>().transform.forward * bulletSpeed;

                // Create the bullet object -> (bullet, gun barrel position, player rotation)
                GameObject b = Instantiate(bullet, transform.position, transform.rotation);
                b.GetComponent<Rigidbody>().velocity = bulletDirection;
            }
        }
    }
}
