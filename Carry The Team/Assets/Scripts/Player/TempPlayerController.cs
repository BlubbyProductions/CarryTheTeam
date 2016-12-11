using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


//public class TempPlayerController : NetworkBehaviour
public class TempPlayerController : MonoBehaviour
{

	private CharacterController Player;
	public bool isGrounded;
	public float gravity;
	public float jumpSpeed;
	public float moveSpeed;
	private float fallSpeed;

	public bool onLadder;
	public float climbSpeed;
	public float climbVelocity;
	private float gravityStore;


	void Start ()
	{
		Player = GetComponent<CharacterController> ();
		gravityStore = gravity;

	}


	// Update is called once per frame
	void Update ()
	{
		IsGrounded ();
		Fall ();
		Jump ();
		Move ();


		if (onLadder)
		{
			gravity = 0f;
		}


		if (!onLadder)
		{
			gravity = gravityStore;
		}


	}

	void Move()
	{
		float xSpeed = Input.GetAxis ("Horizontal");


		if (xSpeed != 0) 
		{			
			Player.Move (new Vector3 (xSpeed, 0) * moveSpeed * Time.deltaTime);
		}
	}



	void Jump()
	{
		if (Input.GetButtonDown ("Jump") && isGrounded) 
		{
			fallSpeed = -jumpSpeed;
		}
	}

	void Fall()
	{
		if (!isGrounded) 
		{
			fallSpeed += gravity * Time.deltaTime;
		} 
		else 
		{
			if (fallSpeed > 0) 
				fallSpeed = 0;
		}
		Player.Move (new Vector3(0, -fallSpeed) * Time.deltaTime);

	}

	void IsGrounded()
	{
		isGrounded = (Physics.Raycast(transform.position, -transform.up, Player.height/1.8F));
	}
		


}
