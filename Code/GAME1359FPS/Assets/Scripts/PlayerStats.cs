using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pInventory();
    }

    public void pInventory()
    {
        GetComponent<Text>().text = "Ammo: " + GameManager.instance.ammo + "\\50" + "\nHealth: " + Mathf.Round(GameManager.instance.playerHP) + "\\100";
    }
}
