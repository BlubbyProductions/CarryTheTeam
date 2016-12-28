using UnityEngine;
using System.Collections;

public class Winner_Trigger : MonoBehaviour
{

	PlayerController controls;
	GameObject player;

	void Start ()
	{
		controls = GetComponent<PlayerController> ();
		player = GetComponent<GameObject> ();
	}
	
	void Update ()
	{
		
	}

	// check to see who entered first, then declare winner
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.CompareTag ("Player")) {
			Debug.Log ("Winner");
			//controls.MovePlayer (new Vector3(-2, 0, 0));
		}
	}
}
