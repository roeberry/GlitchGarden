using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    Button[] buttons;
    public static GameObject selectedDefender;
    Text costText;
    public GameObject defenderPrefab;

    const float WORLD_UNIT = 400f / 3f;

	// Use this for initialization
	void Start () {
        buttons = FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        costText.text = "" + defenderPrefab.GetComponent<Defender>().cost;
	}
	
	// Update is called once per frame
	void Update () {
        if (selectedDefender != defenderPrefab)
        {
            if (defenderPrefab.GetComponent<Defender>().cost > StarsCounter.count)
            {
                GetComponent<SpriteRenderer>().color = Color.black;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.grey;
            }
        }
    }

    private void OnMouseDown()
    {
        foreach(Button b in buttons)
        {
            b.GetComponent<SpriteRenderer>().color = Color.black;
        }
        if (defenderPrefab.GetComponent<Defender>().cost <= StarsCounter.count)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            selectedDefender = defenderPrefab;
        }
    }
}
