using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Header("Bullet Lifetime")]
    float bulletLifetime;

    [SerializeField]
    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= bulletLifetime)
        {
            Debug.Log("Bullet Destroyed After Time Elapsed");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed After Collision With " + collision.gameObject.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            Destroy(other.gameObject);
            Debug.Log("Hazard Destroyed");
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed After Collision");
        }

        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            Debug.Log("Target Destroyed");
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed After Collision");
            GameManager.instance.targetsHit++;
            Debug.Log("Score Increased");
        }
    }
}
