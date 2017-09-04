using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_UNLOCKED_PREFIX_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume){
        if (volume < 0f || volume > 1f)
        {
            Debug.LogError("Master volume out of range");
        }
        else{
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
    }

    public static float GetMasterVolume(){
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void SetDifficulty(int difficulty){
        if(difficulty>3||difficulty<1){
            Debug.LogError("Invaild difficulty");
        }
        else{
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        }
    }

    public static int GetDifficulty(){
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    public static void UnlockLevel(int level){
        if(PlayerPrefs.HasKey(LEVEL_UNLOCKED_PREFIX_KEY+level)){
            if(PlayerPrefs.GetInt(LEVEL_UNLOCKED_PREFIX_KEY + level)==1){
                Debug.LogWarning("Level has already been unlocked. Do nothing.");
            }
            else{
                PlayerPrefs.SetInt(LEVEL_UNLOCKED_PREFIX_KEY + level, 1);
            }
        }
        else{
            Debug.LogError("Unlocking a non-exsistent level");
        }
    }

    public static void AddLevel(int levelIndex){
        if (PlayerPrefs.HasKey(LEVEL_UNLOCKED_PREFIX_KEY + levelIndex))
        {
            Debug.LogError("Level existed");
        }
        else{
           PlayerPrefs.SetInt(LEVEL_UNLOCKED_PREFIX_KEY + levelIndex, 0); 
        }
    }
}
