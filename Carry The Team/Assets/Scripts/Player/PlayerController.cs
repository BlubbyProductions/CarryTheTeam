using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public enum ControlState
{
	Sideways,
	Updwards,
	TopDown,
	Disabled
}

//public class PlayerController : NetworkBehaviour
public class PlayerController : MonoBehaviour
{
	private float MoveSpeed = 10.0f;
	private float JumpSpeed = 30.0f;
	private float Gravity = 9.8f;

	private float Vertical;
	private float Horizontal;
	private float DeltaTime;

	private Vector3 Movement;
	private ControlState state;
	CharacterController Player;

	void Start ()
	{
		Movement = new Vector3 (0, 0, 0);
		state = ControlState.Sideways;
		Player = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		DeltaTime = Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			state = ControlState.Sideways;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			state = ControlState.Updwards;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			state = ControlState.TopDown;
		}
		else if(Input.GetKeyDown(KeyCode.Alpha0)) {
			state = ControlState.Disabled;
		}

		switch (state)
		{
		case ControlState.Sideways:
			HorizontalControls ();
			break;
		case ControlState.Updwards:
			VerticalControls ();
			break;
		case ControlState.TopDown:
			TopDownControls ();
			break;
		case ControlState.Disabled:
			DisableControls ();
			break;
		}
	}

	public void SetControlState(ControlState SetState)
	{
		state = SetState;
	}

	public void MovePlayer(Vector3 OutsideMovement)
	{
		Player.Move (OutsideMovement * DeltaTime);
	}

	void DisableControls()
	{
		Movement = new Vector3 (0, 0, 0);
		Player.Move (Movement * DeltaTime);
	}

	// movement in the x-axis
	void HorizontalControls()
	{
		Horizontal = Input.GetAxis ("Horizontal");

		Movement.x = Horizontal * MoveSpeed;

		// if the player presses the jump key
		/*if (Player.isGrounded && Input.GetButton("Jump"))
		{
			Debug.Log ("Jump Applied");
			Movement.y = JumpSpeed;
		}*/

		// apply gravity
		//Movement.y -= Gravity;

		Player.Move (Movement * DeltaTime);
	}

	// movement in the y-axis
	void VerticalControls()
	{
		Vertical = Input.GetAxis ("Vertical");
		Movement.y = Vertical * MoveSpeed;

		// Movement.y += Gravity
		Player.Move (Movement * DeltaTime);
	}

	// movement from above the player
	void TopDownControls()
	{
		Horizontal = Input.GetAxis ("Horizontal");
		Vertical = Input.GetAxis ("Vertical");

		Movement.x = Horizontal * MoveSpeed;
		Movement.z = Vertical * MoveSpeed;

		Player.Move (Movement * DeltaTime);
	}
}
