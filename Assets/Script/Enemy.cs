using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	Vector2 APoint, BPoint;
	public float hp, speed, Area,stopArea, AreaAttack, ScaleX, JumpForce, RandomA, RandomB;
	public GameObject Player, BarHp;
	private Animator anim;
	public bool isPointB = false,isPointA = false, onGround = false, onRight = false;
	private Rigidbody2D rb;
	public LayerMask WhatisGround;
	public int maxHealth = 30, currentHealt;
	public HeartBar healthBar;
	public AudioSource EnemyAttackSound;
	Transform HpBar;

	void Start () {
		// Definisikan Scale Rotation
		ScaleX = transform.localScale.x;
		//Definisikan Animation Enemy
		anim = GetComponent<Animator> ();
		//Definisikan RigidBody Enemy
		rb = GetComponent<Rigidbody2D> ();
		//Definisikan Healt Enemy
		currentHealt = maxHealth;
		healthBar.setMaxHealt(maxHealth);
		HpBar = BarHp.transform;

	}

	void Update () {
		//Definisikan Titik Point Patrol
		APoint = new Vector2 (RandomA, transform.position.y);
		BPoint = new Vector2 (RandomB, transform.position.y);
		//Definisikan Posisi Enemy X
		float enemytrol = transform.position.x;
	
		//Definiskan Void Lompat
		Lompat ();
		//Definiskan Titik Point Player dalam bentuk Transform
		Transform follow = Player.transform;
		//Definisikan atau mengukur Jarak Antara Titik Point dengan Player
		float destince = Vector2.Distance (transform.position, follow.position);
		float destincePoint = Vector2.Distance (transform.position, APoint + BPoint / 2);
		//Ketika Jarak Player lebih kecil dari jarak atau area yang telah ditentukan
		if (destince < Area ) {
			//Definisikan Titik Player dalam float
			float followPlayerX = follow.transform.position.x;
			//Keika Player Berada di sebelah kanan
			if (followPlayerX > enemytrol) {
				transform.position = Vector2.MoveTowards (transform.position, follow.position, speed * Time.deltaTime);
				anim.SetBool ("IsRunning", true);
				transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);
				HpBar.transform.localScale = new Vector3 (-ScaleX, transform.localScale.y, transform.localScale.z);
			}
			//Ketika Player Berada di sebelah Kiri
			if (followPlayerX < enemytrol) {
				transform.position = Vector2.MoveTowards (transform.position, follow.position, speed * Time.deltaTime);
				anim.SetBool ("IsRunning", true);
				transform.localScale = new Vector3 (-ScaleX, transform.localScale.y, transform.localScale.z);
				HpBar.transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);
			}
			//Ketika Player Di Area Enemy untuk menyerang
			if (destince <= AreaAttack) {
				EnemyAttackSound.Play();
				anim.SetBool ("IsRunning", false);
				anim.SetBool ("IsAttack", true);
			} 
			// Ketika Player ada DiAtas Enemy
			else if (destince == followPlayerX) {
				anim.SetBool ("IsRunning", false);
				anim.SetBool ("IsAttack", false);
				Lompat ();
			}else {
				anim.SetBool ("IsRunning", true);
				anim.SetBool ("IsAttack", false);
			}
		} else if (destincePoint > stopArea) {
			Patrol ();
		} else if (destince > Area) {
			Patrol ();
		}
	}

	//Fungsi Lompat Jika ada Halangan Didepan Enemy
	void Lompat(){
		onRight = Physics2D.Raycast (transform.position, Vector2.right, 0.2f, WhatisGround);

		if (onRight == true) {
			anim.SetBool ("IsRunning", false);
			rb.velocity = Vector2.up * JumpForce;
		} else {
			anim.SetBool ("IsRunning", true);
		}
	}

	//Fungsi Patrol
	void Patrol(){
		APoint = new Vector2 (RandomA, transform.position.y);
		BPoint = new Vector2 (RandomB, transform.position.y);
		float enemytrol = transform.position.x;
		Transform follow = Player.transform;
		if (RandomB >= enemytrol && isPointB == false) {
			transform.position = Vector2.MoveTowards (transform.position, BPoint, speed * Time.deltaTime);
			anim.SetBool ("IsRunning", true);
			transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);
			isPointA = true;
			HpBar.transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);

		} else if (enemytrol > RandomA) {
			transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);
			HpBar.transform.localScale = new Vector3 (-ScaleX, transform.localScale.y, transform.localScale.z);
			isPointA = false;
		}
		if (RandomB == enemytrol) {
			isPointB = true;
			isPointA = false;
		}

		if (enemytrol > RandomA && isPointA == false) {
			transform.position = Vector2.MoveTowards (transform.position, APoint, speed * Time.deltaTime);
			anim.SetBool ("IsRunning", true);
			transform.localScale = new Vector3 (-ScaleX, transform.localScale.y, transform.localScale.z);
			isPointB = true;
			HpBar.transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);
		} else if (RandomB >= enemytrol) {
			transform.localScale = new Vector3 (ScaleX, transform.localScale.y, transform.localScale.z);
			HpBar.transform.localScale = new Vector3 (-ScaleX, transform.localScale.y, transform.localScale.z);
			isPointB = false;
		}
		if (enemytrol == RandomA) {
			isPointA = true;
			isPointB = false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//Ketika Terkena Pedang Player
		if (other.gameObject.tag == "Pedang") {
			TakeDamge (2);
		}
	}

	//Fungsi Pada Darah Enemy
	void TakeDamge(int damage){
		currentHealt -= damage;
		healthBar.SetHealth (currentHealt);
	}
}
