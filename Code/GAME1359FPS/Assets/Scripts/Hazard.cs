using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField, Header("Hazard Info")]
    public float damageSpeed;

    [SerializeField, Header("In Hazard")]
    private bool inHazard = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inHazard == true)
        {
            GameManager.instance.playerHP -= damageSpeed * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered Hazard");
            inHazard = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Exited Hazard");
            inHazard = false;
        }
    }
}
