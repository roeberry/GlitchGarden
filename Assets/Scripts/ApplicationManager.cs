using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ApplicationManager : MonoBehaviour {

    public float autoLoadNextLevel;

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    public void LoadScene(string name){
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Start()
    {
        if (autoLoadNextLevel > 0f)
        {
            Invoke("LoadNextLevel", autoLoadNextLevel);
        }
    }

    public void Pause(){
        Time.timeScale = 1 - Time.timeScale;
    }
}
