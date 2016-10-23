using UnityEngine;
using System.Collections;

public class CCPlayer : MonoBehaviour {

	public float speed;
	public float jumpHeight;
	public float fallSpeed;
	private bool isGrounded;
	private float gravity;

	CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		gravity = -9.8f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		IsGrounded ();
		IsFalling ();
		Movement ();
		Debug.Log (isGrounded);
	}

	void Movement() {
		float horizontal = Input.GetAxis ("Horizontal");
		//Vector3 move = new Vector3(horizontal, 0.0f, 0.0f);
		//controller.Move (new Vector3(horizontal, 0.0f, 0.0f));
	}

	void IsFalling() {
		if (!isGrounded) {
			fallSpeed += gravity * Time.deltaTime;
		}

		controller.Move (new Vector3(0.0f, fallSpeed * Time.deltaTime, 0.0f));
	}

	void IsGrounded() {
		//isGrounded = Physics.Raycast (transform.position, -transform.up, controller.height / 1.9f);
		isGrounded = controller.isGrounded;
	}
}
