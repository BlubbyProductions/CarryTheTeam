using UnityEngine;
using System.Collections;

// rigidbody works but not as responsive to immediate turns
// could be used for the future
public class TempScript : MonoBehaviour {

	private float speed;
	private float hAxis;
	private float vAxis;

	Vector3 movement;
	Rigidbody player;
	// Use this for initialization
	void Start () {
		speed = 30;
		movement = new Vector3 (0, 0, 0);
		player = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		hAxis = Input.GetAxis ("Horizontal");
		vAxis = Input.GetAxis ("Vertical");

		movement = new Vector3 (hAxis, 0, vAxis);
		player.AddForce (movement * speed, ForceMode.Impulse);
	}
}
