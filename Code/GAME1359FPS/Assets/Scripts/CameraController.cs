using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Header("Camera Speed")]
    float rotSpeed = 650;

    [SerializeField]
    Transform lookUpDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse X Axis
        float x = Input.GetAxis("Mouse X");
        // Mouse Y Axis
        float y = Input.GetAxis("Mouse Y");

        // Camera rotation around the Y axis for horizontal camera movement
        transform.Rotate(new Vector3(0, x * rotSpeed * Time.deltaTime, 0));
        // Camera rotation around the X axis for vertical camera movement
        lookUpDown.Rotate(new Vector3((y * -1) * rotSpeed * Time.deltaTime, 0, 0));
    }
}
