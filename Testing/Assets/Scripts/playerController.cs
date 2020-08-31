using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	Rigidbody rb;

	public float speed;
	public float jump;

	public bool isRight = true;

	public Transform groundCP;
	public float groundCR;
	public LayerMask whatIsGround;
	public Collider[] isGrounded;

	Animator animator;

	//Power-up timer 
	private float powerUpTimer = 0f;
	public float powerUpDuration = 20f;
	private bool powerUpOn = false;

	void Start()
    {
        //Get Rigidbody
		rb = GetComponent<Rigidbody>();

		//Get Animator 
		animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
		Collider[] isGrounded = Physics.OverlapSphere(groundCP.position, groundCR, whatIsGround);

		if (Input.GetKey("d") && Input.GetKey("a") == false){
			rb.velocity = new Vector3(speed,rb.velocity.y,0);
			var running = animator.GetBool("Running");
			running = true;
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

	public void Update()
	{
		//Timer for powerup
		if (powerUpOn == true)
		{
			powerUpTimer += Time.deltaTime;

			if (powerUpTimer > powerUpDuration)
			{
				ResetStats();
				powerUpOn = false;
			}
		}
	}

	public void PowerUpOnTrue()
    {
		powerUpOn = true;
    }

	public void ChocolateBar()
    {
		//change whatever values you want to the chocolate bar to give
		speed = 5;
		jump = 30;
		Debug.Log("Chocolate bar was eaten");
    }

	public void Lollipop()
    {
		//add power up for lolipop
		Debug.Log("Player ate a lollipop");
    }

	public void CandyApple()
    {
		//add power up for candy apple
		Debug.Log("Player ate a candy apple");
		// Hp + 1 
    }

	public void ResetStats()
    {
		//Set the stats back to their default values
		speed = 10;
		jump = 20;
    }
}
