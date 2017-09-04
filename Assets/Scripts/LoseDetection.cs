using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseDetection : MonoBehaviour {

    public static int health=3;
    public GameObject app;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "" + health;
        if (health <= 0)
        {
            app.GetComponent<ApplicationManager>().LoadScene("03 Lose");
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DestroyObject(collision.gameObject);
        health--;
    }
}
