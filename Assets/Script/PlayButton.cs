using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
	public GameObject SettingMenu, MenuLevel;
	public AudioSource ButtonAudio;
	
	public void Play()
    {
		Time.timeScale = 1f;
		ButtonAudio.Play();
		MenuLevel.SetActive(true);
    }

	public void Setting()
    {
		Time.timeScale = 1f;
		SettingMenu.SetActive(true);
		ButtonAudio.Play();
    }

	public void Exit()
    {
		ButtonAudio.Play();
		Application.Quit();
    }

	public void Level1()
    {
		Time.timeScale = 1f;
		ButtonAudio.Play();
		SceneManager.LoadScene("Tutorial");
    }

	public void ButtonX()
    {
		Time.timeScale = 1f;
		ButtonAudio.Play();
		MenuLevel.SetActive(false);
    }
	
}
