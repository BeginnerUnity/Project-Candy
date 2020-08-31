using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateBar : MonoBehaviour
{

    public Collider player;
    public GameObject playerScript;

    private void OnTriggerEnter(Collider col)
    {
        if(col == player)
        {
            // add a sound when collected
            Destroy(this.gameObject);
            playerScript.GetComponent<playerController>().ChocolateBar();
        }
    }
}
