using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	Transform myTransform;
	public float verticalSpeed = 10.0f;
	public float jumpHeight = 15.0f;
	float dT; // deltaTime

	Rigidbody rbplayer;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = gameObject;
		myTransform = transform;
		//rbplayer = player.AddComponent<Rigidbody2D>() as Rigidbody2D;
	}
	
	// Update is called once per frame
	void Update () {
		dT = Time.deltaTime;

		if (Input.anyKey) {
			switch (Input.inputString) {
			case "a": // character moves left
				player.GetComponent<Rigidbody>().velocity = new Vector3 (-verticalSpeed * dT, 0.0f, 0.0f);
				break;
			case "d": // character moves right
				player.GetComponent<Rigidbody>().velocity = new Vector3 (verticalSpeed * dT, 0.0f, 0.0f);
				break;
			/*case "space":
				player.GetComponent<Rigidbody2D> ().AddForce = new Vector2 (0.0f, jumpHeight * dT);
				break;*/
			}
		}
	}
}
