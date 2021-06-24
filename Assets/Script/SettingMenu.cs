using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour {
	public AudioMixer audioMixer;
	public AudioSource ButtonAudio;
	public GameObject PauseMenu;
	public float volume;
	public Slider SliderGame;
	public Dropdown MenuGraphic;
	public int graphic1;

	public void Start()
    {
		audioMixer.GetFloat("Volume", out float volume);
		print(volume);
		SliderGame.value = volume ;
		graphic1 = QualitySettings.GetQualityLevel();
		print(graphic1);
		MenuGraphic.value = graphic1;
	}

    public void SetVolume(float volume ) {
		audioMixer.SetFloat("Volume", volume);
	}

	public void setQuality(int qualityIndex) {
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	public void ButtonX() {
		Time.timeScale = 1f;
		ButtonAudio.Play();
		gameObject.SetActive(false);
		PauseMenu.SetActive(true);
	}
}
