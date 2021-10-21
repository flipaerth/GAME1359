using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetCount();
    }

    public void targetCount()
    {
        GetComponent<Text>().text = "Targets: " + GameManager.instance.targetsHit + "\\" + GameManager.instance.totalTargets + "\nTargets Left: " + GameManager.instance.targetsRemaining;
    }
}
