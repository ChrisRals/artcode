using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour {

	private Player1 playerground;

	// Use this for initialization
	void Start () {
		playerground = GetComponentInParent<Player1> ();
	}
	
	// Update is called once per frame
	void OnCollisionStay2D(Collision2D col) {
		playerground.Grounded = true;
		if (col.gameObject.tag == "Platform") {
			playerground.transform.parent = col.transform;
			playerground.Grounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D col) {
		playerground.Grounded = false;
		if (col.gameObject.tag == "Platform") {
			playerground.transform.parent = null;
			playerground.Grounded = false;
		}
	}
}
