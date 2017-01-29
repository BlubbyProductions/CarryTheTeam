using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

enum StopLight
{
	Greenlight,
	Redlight
}

public class Stoplight_Behavior : MonoBehaviour
{
	private float MinGreenlightDuration;
	private float MaxGreenlightDuration;
	private float MinRedlightDuration;
	private float MaxRedlightDuration;
	private float Init_Start_Time;
	// determines how much time can pass while receiving player input on redlight
	private float Player_Error_Time;

	private bool GameStart; // whether the minigame has started or not

	//////////////////////////////////////////////////
	private float WaitTimeForLightChange = 0;
	private float ElapsedTime = 0;
	//////////////////////////////////////////////////

	StopLight CurrentLight;
	Renderer GreenLight;
	Renderer RedLight;
	PlayerController controls;
	
	void Start ()
	{
		Init_Start_Time = 5; // the initial start time is to wait 3 seconds
		
		MinGreenlightDuration = 4;
		MaxGreenlightDuration = 7;
		MinRedlightDuration = 4;
		MaxRedlightDuration = 8;

		CurrentLight = StopLight.Redlight;

		GreenLight = GameObject.Find ("Green Light").GetComponent<Renderer> ();
		RedLight = GameObject.Find ("Red Light").GetComponent<Renderer> ();
		GreenLight.material.color = new Color (0, 0, 0, 0);

		controls = GameObject.FindObjectOfType (typeof(PlayerController)) as PlayerController;

		GameStart = false;
		controls.SetControlState (ControlState.Disabled);
	}

	void Update ()
	{
		// countdown timer to start the game
		// start at 5 and decrease it every second
		// 
		if (Time.time < Init_Start_Time && Time.time > ElapsedTime)
		{
			ElapsedTime++;
			if (ElapsedTime == 5)
			{
				GameStart = true;
				controls.SetControlState (ControlState.Sideways);
				Debug.Log (GameStart);
			}
			//Debug.Log (Mathf.Abs(ElapsedTime));
		}
		else if (Time.time > ElapsedTime && GameStart)
		{
			if (CurrentLight == StopLight.Redlight)
			{
				CurrentLight = StopLight.Greenlight;
			} 
			else
			{
				CurrentLight = StopLight.Redlight;
			}

			ChangeLights();
		}
		CheckInput ();
	}

	void ChangeLights()
	{
		switch(CurrentLight)
		{
		case StopLight.Redlight:
			WaitTimeForLightChange = Random.Range (MinRedlightDuration, MaxRedlightDuration);
			RedLight.material.color = new Color (1, 0, 0, 1);
			GreenLight.material.color = new Color (0, 0, 0, 0);
			break;
		case StopLight.Greenlight:
			WaitTimeForLightChange = Random.Range(MinGreenlightDuration, MaxGreenlightDuration);
			RedLight.material.color = new Color (0, 0, 0, 0);
			GreenLight.material.color = new Color (0, 1, 0, 1);
			break;
		}

		//Debug.Log("Wait " + Mathf.Floor(WaitTimeForLightChange) + " seconds; Current light is " + CurrentLight);
		ElapsedTime = Mathf.Floor(Time.time + WaitTimeForLightChange);
	}

	void CheckInput()
	{
		if (Input.GetAxis ("Horizontal") > 0 && CurrentLight == StopLight.Redlight && GameStart) {
			Debug.Log ("Move back jerk");
			controls.SetControlState (ControlState.Disabled);
			controls.MovePlayer (new Vector3(-15, 0, 0));
			controls.SetControlState (ControlState.Sideways);
		}
	}
}
