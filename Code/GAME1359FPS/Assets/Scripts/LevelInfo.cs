using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = "1. Shoot the targets!\n\n2. Standing near barrels\n    hurts you!\n\n3. Pick up ammo packs\n    if you run out!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
