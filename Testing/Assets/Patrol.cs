using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	public float speed;
    public float distance;
    private bool movingRight = true;

    public Transform groundDetection;
	public LayerMask whatIsGround;

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector2.right * speed * Time.deltaTime);
    	RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector3.down, distance, whatIsGround);
        Debug.DrawRay(groundDetection.position, Vector3.down, Color.green);
		if(groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
				Debug.Log("poop");
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}
