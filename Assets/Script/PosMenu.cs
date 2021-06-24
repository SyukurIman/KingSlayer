using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PosMenu : MonoBehaviour {
	public static bool GameIsPaused = false;
	public AudioSource ButtonAudio;
	public GameObject PauseMenuUi, ButtonMouse, SettingMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			}else {
				Pause ();
			}
		} 
	}

	public void Resume () {
		PauseMenuUi.SetActive (false);
		SettingMenu.SetActive(false);
		ButtonMouse.SetActive (true);
		Time.timeScale = 1f;
		GameIsPaused = false;
		ButtonAudio.Play();
	}
	public void Pause (){
		ButtonAudio.Play();
		PauseMenuUi.SetActive (true);
		ButtonMouse.SetActive (false);
		Time.timeScale = 0f;
		GameIsPaused = true;

	}

	public void LoadMenu(){
		ButtonAudio.Play();
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");
	}

	public void Setting() {
		ButtonAudio.Play();
		PauseMenuUi.SetActive(false);
		SettingMenu.SetActive(true);
	}

	public void Restart(){
		ButtonAudio.Play();
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Tutorial");
	}
}
