using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
	public float speed;
    public float distance;
    public bool movingRight = true;
	public bool isTouching;

    public Transform groundDetection;
	public LayerMask whatIsGround;

    // Update is called once per frame
    void fixedUpdate()
    {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
    	RaycastHit hit;
		if(Physics.Raycast(groundDetection.position, Vector3.down,out hit, distance) == true){
			isTouching = true;
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
