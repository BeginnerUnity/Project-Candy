using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

      
        if (Physics.Raycast(groundDetection.position, Vector3.down, distance) == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }
}

