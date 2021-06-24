using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
	GameObject player;
	public Animator anim;
	public AudioSource Pedang;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Hero");
	}
	void Update () {
	}
	public void OnMouseDown (){
		if (gameObject.tag == "ButtonKanan") {
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Kanan ();
		} else if (gameObject.name == "ButtonKiri") {
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Kiri ();
		} else if (gameObject.name == "ButtonLompat") {
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Jump2 = true;
			player.GetComponent<MovementKing> ().Lompat ();
		} else if (gameObject.name == "ButtonAttack") {
			Pedang.Play();
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Attack ();
		} else if (gameObject.name == "ButtonLompat" && gameObject.name == "ButtonKanan") { // Dipertanyakan ??
			player.GetComponent<MovementKing> ().Jump2 = true;
			player.GetComponent<MovementKing> ().Lompat ();
			player.GetComponent<MovementKing> ().Kanan ();
		} else if (gameObject.name == "ButtonLompat" && gameObject.name == "ButtonKiri") {
			player.GetComponent<MovementKing> ().Jump2 = true;
			player.GetComponent<MovementKing> ().Lompat ();
			player.GetComponent<MovementKing> ().Kiri ();
		} 
	}
	public void OnMouseUp (){
		if (gameObject.name == "ButtonKanan") {
			anim.SetBool ("IsRunning", true);
			player.GetComponent<MovementKing> ().anim.SetBool ("IsRuning", false);
		} else if(gameObject.name == "ButtonKiri"){
			anim.SetBool ("IsRunning", true);
			player.GetComponent<MovementKing> ().anim.SetBool ("IsRuning", false);
		}else if (gameObject.name == "ButtonAttack") {
			anim.SetBool ("IsRunning", true);
			player.GetComponent<MovementKing> ().anim.SetBool ("IsRuning", false);
		} else if (gameObject.name == "ButtonLompat") {
			anim.SetBool ("IsRunning", true);
			player.GetComponent<MovementKing> ().Jump2 = false;
		} else if (gameObject.name == "ButtonLompat" && gameObject.name == "ButtonKanan") {
			player.GetComponent<MovementKing> ().Jump2 = false;
			player.GetComponent<MovementKing> ().anim.SetBool ("IsRuning", false);
		} else if (gameObject.name == "ButtonLompat" && gameObject.name == "ButtonKiri") {
			player.GetComponent<MovementKing> ().Jump2 = false;
			player.GetComponent<MovementKing> ().anim.SetBool ("IsRuning", false);
		} 
	}
	public void OnMouseDrag (){
		if (gameObject.name == "ButtonKanan") {
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Kanan();
		} else if(gameObject.name == "ButtonKiri"){
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Kiri();
		} else if (gameObject.name == "ButtonLompat") {
			anim.SetTrigger ("IsTrigert");
			player.GetComponent<MovementKing> ().Jump2 = true;
			player.GetComponent<MovementKing> ().Lompat ();
		} else if (gameObject.name == "ButtonLompat" && gameObject.name == "ButtonKanan") {
			player.GetComponent<MovementKing> ().Jump2 = true;
			player.GetComponent<MovementKing> ().Lompat ();
			player.GetComponent<MovementKing> ().Kanan ();
		} else if (gameObject.name == "ButtonLompat" && gameObject.name == "ButtonKiri") {
			player.GetComponent<MovementKing> ().Jump2 = true;
			player.GetComponent<MovementKing> ().Lompat ();
			player.GetComponent<MovementKing> ().Kiri ();
		} 
	}
}
