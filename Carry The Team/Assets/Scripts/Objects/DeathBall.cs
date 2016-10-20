using UnityEngine;
using System.Collections;

public class DeathBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			Destroy (gameObject);
	}
	*/

	void OnTriggerEnter(Collider other)
	{
			Destroy(other.gameObject);
	}


}
