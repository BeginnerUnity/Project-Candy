using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateBar : MonoBehaviour
{
    //Attach the Player
    public Collider player;
    public GameObject playerScript;

    //When power is collected by the player
    private void OnTriggerEnter(Collider col)
    {
        if(col == player)
        {
            // add a sound when collected
            playerScript.GetComponent<playerController>().ChocolateBar();
            playerScript.GetComponent<playerController>().PowerUpOnTrue();
            Destroy(this.gameObject);
        }
    }
}
