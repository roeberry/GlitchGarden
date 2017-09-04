using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelChangeMusicArray;

    public float volume = 1f;

    private AudioSource audioSource;

    private void Awake()
    {
		DontDestroyOnLoad(gameObject);
        volume = PlayerPrefsManager.GetMasterVolume();
        PlayerPrefsManager.SetDifficulty(1);
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
		audioSource.clip = levelChangeMusicArray[0];
		audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
        audioSource.volume = volume;
	}

    private void OnLevelWasLoaded(int level)
    {
        AudioClip audioClip = levelChangeMusicArray[level];
        if(audioClip){
			audioSource.clip = levelChangeMusicArray[level];
			audioSource.Play();
		}
    }
}
