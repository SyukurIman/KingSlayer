using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMainMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
	public AudioSource ButtonAudio;
	public GameObject PauseMenu;
	public float volumeMenu;
	public Slider MenuSlider;
	public Dropdown MenuGraphic;
	public int graphic1;

    public void Start()
    {
		audioMixer.GetFloat("Volume", out float volume);
		print(volume);
		MenuSlider.value = volume;
		graphic1 = QualitySettings.GetQualityLevel();
		MenuGraphic.value = graphic1;
		print(graphic1);
	}
    public void SetVolume(float volume)
	{
		audioMixer.SetFloat("Volume", volume);
		volumeMenu = volume;
	}

	public void setQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}
	public void ButtonX()
	{
		Time.timeScale = 1f;
		ButtonAudio.Play();
		gameObject.SetActive(false);
	}
}
