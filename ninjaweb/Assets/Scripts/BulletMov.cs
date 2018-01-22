using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour {

	public GameObject player;
	private Transform playerTrans;

	private Rigidbody2D bulletRB;

	public float bulletSpeed;

	public float bulletLife;

	void Awake()
	{
		bulletRB = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerTrans = player.transform;
	}

	// Use this for initialization
	void Start () {
		if (playerTrans.localScale.x > 0) 
		{
			bulletRB.velocity = new Vector2 (bulletSpeed, bulletRB.velocity.y);
		}
		else
		{
			bulletRB.velocity = new Vector2 (bulletSpeed, bulletRB.velocity.y);
		}
	}
	
	// Update is called once per frame

	void Update () {
		Destroy (gameObject, bulletLife);
	}

}
