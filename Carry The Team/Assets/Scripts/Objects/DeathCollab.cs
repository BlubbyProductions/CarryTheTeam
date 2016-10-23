using UnityEngine;
using System.Collections;

public class DeathCollab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	void OnTriggerEnter(Collider other)
	{
		switch(gameObject.tag)
		{
			case "DeathBall":
				Destroy (gameObject);
				break;
			default:
				Destroy (other.gameObject);
				break;
		}
	}
}
