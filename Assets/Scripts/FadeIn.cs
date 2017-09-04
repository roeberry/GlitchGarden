using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInDuration = 0.5f;
    Image fadeInPanel;

	// Use this for initialization
	void Start () {
        fadeInPanel = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad <= fadeInDuration)
        {
            float alpha = 1f - Time.timeSinceLevelLoad / fadeInDuration;
            Color newColor = fadeInPanel.color;
            newColor.a = alpha;
            fadeInPanel.color = newColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
	}
}
