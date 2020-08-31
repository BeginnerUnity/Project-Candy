using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
	Rigidbody rb;
	public float speed;
    public float distance;
    public bool movingRight = true;
    public Transform groundDetection;
	public LayerMask whatIsGround;

	void start()
	{
		rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void fixedUpdate()
    {
		rb.velocity = new Vector3(speed,rb.velocity.y,0);
    	RaycastHit hit;
		if(Physics.Raycast(groundDetection.position, Vector3.down,out hit, distance) == true){
            if(movingRight == true)
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
        Debug.DrawRay(groundDetection.position, Vector3.down, Color.green);

    }
}
