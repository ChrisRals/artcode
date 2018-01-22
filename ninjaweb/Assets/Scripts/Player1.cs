using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1 : MonoBehaviour {

	public float speed;
	public float jumpSpeed;
	public int contador;
	public bool Grounded;
	public bool Jumptest;
	public bool ShootTest;
	public float countdown = 0.6f;
	public Transform bulletStart;
	public GameObject bulletPrefab;



	private Rigidbody2D rb2d;
	private Animator anim;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer ();
		JumpPlayer ();
		ShootPlayer ();
		anim.SetFloat ("speedanim", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool ("grounded", Grounded);
		anim.SetBool ("jumptest", Jumptest);
		anim.SetBool ("shoottest", ShootTest);
		countdown -= Time.deltaTime;
		if (countdown <= 0.0f) {
			ShootTest = false;
		}
	}

	void MovePlayer() {
		rb2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb2d.velocity.y);
		if(rb2d.velocity.x < 0)
		{
			GetComponent<SpriteRenderer>().flipX = true;
		}
		else if(rb2d.velocity.x > 0)
		{
			GetComponent<SpriteRenderer>().flipX = false;
		}
		else
		{
			
		}
	}
	void JumpPlayer ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Jumptest = true;
			if (contador < 1) 
			{
				rb2d.AddForce (Vector2.up * jumpSpeed, ForceMode2D.Impulse);
				contador += 1;
			}
		}
	}


	void ShootPlayer (){
		if (Input.GetKeyDown (KeyCode.Z)) {
			ShootTest = true;
			countdown = 0.6f;
			Instantiate(bulletPrefab, bulletStart.position, bulletStart.rotation);
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		contador = 0;
	}
	void OnBecameInvisible(){
		transform.position = new Vector3 (0, 0, 0);
	}

}
