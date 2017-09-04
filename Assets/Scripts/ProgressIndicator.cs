using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressIndicator : MonoBehaviour {

    float time;
    public float levelTime;
    public GameObject app;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        if(Time.timeSinceLevelLoad > levelTime){
            GameObject attacker = GameObject.Find("Attackers");
            if(!HasChild(attacker)){
                levelTime = float.MaxValue;
                GetComponent<AudioSource>().Play();
                Invoke("LoadNextLevel", 2f);
            }
        }
	}

    bool HasChild(GameObject o){
        foreach(Transform t in o.transform){
            return true;
        }
        return false;
    }

    void LoadNextLevel(){
        app.GetComponent<ApplicationManager>().LoadNextLevel();
    }
}
