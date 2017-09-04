using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour {

    const float defaultVolume = 1f;

    public Slider volumeSlider;
    public Toggle easy;
    public Toggle normal;
    public Toggle hard;

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = FindObjectOfType<MusicManager>();
        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        int difficulty = PlayerPrefsManager.GetDifficulty();
        switch(difficulty){
            case 1:
                easy.isOn=true;
                break;
            case 2:
                normal.isOn=true;
                break;
            case 3:
                hard.isOn=true;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
        musicManager.volume = volumeSlider.value;
	}

    public void Save(){
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        if(easy.isOn){
            PlayerPrefsManager.SetDifficulty(1);
        }else if(normal.isOn){
            PlayerPrefsManager.SetDifficulty(2);
        }else if(hard.isOn){
            PlayerPrefsManager.SetDifficulty(3);
        }
    }

    public void SetToDefault(){
        volumeSlider.value = defaultVolume;
        normal.isOn=true;
    }
}
