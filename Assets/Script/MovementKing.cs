using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKing : MonoBehaviour {
	Rigidbody2D rb;
	public float speed, scaleX, JumpForce, ButtonKanan = 0, ButtonKiri = 0;
	public bool onGround = false, doublejump = false,Jump = false, Jump2 = false;
	public Transform groundPos;
	public LayerMask WhatisGround;
	public Animator anim;
	public int maxHealth, currentHealt;
	public bool idle = false;


	public HeartBar healthBar;

	public void Start () {
		rb = GetComponent<Rigidbody2D>();
		scaleX = transform.localScale.x ;
		anim = GetComponent<Animator> ();
		currentHealt = maxHealth;
		healthBar.setMaxHealt(maxHealth);


	}

	void Update () {
	}

	public void Idle() {
		anim.SetBool ("IsRuning", false);
	}

	public void Kanan (){
		ButtonKanan = 1;
		if (Input.GetKeyDown (KeyCode.RightArrow) || ButtonKanan == 1 ) {
			idle = false;
			transform.localScale = new Vector3 (scaleX, transform.localScale.y, transform.localScale.z);
			transform.Translate (Vector3.right * speed * Time.fixedDeltaTime, Space.Self);
			anim.SetBool ("IsRuning", true);
		}
	}
	public void Kiri (){
		ButtonKiri = 1;
		if (Input.GetKey (KeyCode.LeftArrow) || ButtonKiri == 1 ) {
			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
			anim.SetBool ("IsRuning", true);
			transform.Translate (Vector3.left * speed * Time.fixedDeltaTime, Space.Self);
		}
	}

	public void Lompat() {
		//Definisi
		Jump = true;
		onGround = Physics2D.Raycast (transform.position, Vector2.down, 0.1f, WhatisGround);

		//Lompat
		if (onGround == true && Jump || onGround == true  && Jump2 == true ) {
			anim.SetTrigger ("IsTrigert");
			rb.velocity = Vector2.up * JumpForce;
		}
		if (doublejump == true && Jump || doublejump == true && Jump2) {
			doublejump = false;
			anim.SetTrigger ("IsTrigert");
			rb.velocity = Vector2.up * JumpForce;
		}

		if (onGround == true) {
			rb.gravityScale = 1;
			doublejump = true;
		} else {
			rb.gravityScale = 2;
		}
	}

	public void Attack(){
		anim.SetTrigger ("IsAttack");
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Enemy") {
			TakeDamge (1);
		}
	}

	void TakeDamge(int damage){
		currentHealt -= damage;
		healthBar.SetHealth (currentHealt);
	}
}
