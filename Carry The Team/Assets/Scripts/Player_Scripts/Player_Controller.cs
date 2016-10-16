using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {

	GameObject player;
	public Rigidbody2D prb;
	// Use this for initialization
	void Start () {
		prb = GetComponent<Rigidbody2D>();
		player = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) {
			prb.AddForce (new Vector2(0, 3), ForceMode2D.Impulse);

		}
	}
}
