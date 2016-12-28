using UnityEngine;
using System.Collections;

public class PoleZone : MonoBehaviour 
{

	private TempPlayerController thePlayer;


	// Use this for initialization
	void Start () 
	{
		thePlayer = FindObjectOfType<TempPlayerController> ();
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Player") 
		{
			thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.name == "Player") 
		{
			thePlayer.onLadder = false;
		}
	}
}
