using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
		Rigidbody rb;

		public float speed;
		public float jump;

		public bool isRight;

		public Transform groundCP;
		public float groundCR;
		public LayerMask whatIsGround;
		public Collider[] isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
		isRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Collider[] isGrounded = Physics.OverlapSphere(groundCP.position, groundCR, whatIsGround);

		if (Input.GetKey("d") && Input.GetKey("a") == false){
			rb.velocity = new Vector3(speed,rb.velocity.y,0);
			if (!isRight){
				isRight = true;
				rb.transform.Rotate(0,180,0);
			}
		} 
		else if (Input.GetKey("a") && Input.GetKey("d") == false){
			rb.velocity = new Vector3(-speed,rb.velocity.y,0);
			if (isRight){
				isRight = false;
				rb.transform.Rotate(0,180,0);
			}
		}
		else{
			rb.velocity = new Vector3(0,rb.velocity.y,0);
		}
		if (isGrounded.Length >= 1){
			if (Input.GetKey("space")){

				rb.velocity = new Vector3(rb.velocity.x,jump,0);
			}
		}
    }
}
