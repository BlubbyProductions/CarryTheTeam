using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	public float MaxMoveSpeed;
	public float MaxJumpHeight = 30.0f;



	float dT; // deltaTime

	Rigidbody rbplayer;

	// Use this for initialization
	void Start () {
		rbplayer = GetComponent<Rigidbody> ();
	}

	void Update()  {
		
	}

	// fixed update is used when dealing with rigidbody calculations
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal");
		float jump = Input.GetAxis ("Jump");
		Vector3 move = new Vector3 (horizontal, jump, 0.0f);

		rbplayer.AddForce (move * MaxMoveSpeed);

		Debug.Log (move * MaxMoveSpeed);
	}
}