using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {
    
    public GameObject sunflower;
    Vector2 pos;
    float interval;
    float dimDuration = 0.3f;
    float dimCounter;
    bool isClicked;
    bool isAdded; //Indicates whether the star has been added

	// Use this for initialization
	void Start () {
        pos = sunflower.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
        if ((interval += Time.deltaTime) > 1.2f)
        {
            if (Mathf.Abs(transform.position.y - pos.y) < 0.01)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
        if (isClicked)
        {
            dimCounter += Time.deltaTime;
            if (dimCounter < dimDuration)
            {
                Color newColor = GetComponent<SpriteRenderer>().color;
                newColor.a = 1f - dimCounter / dimDuration;
                GetComponent<SpriteRenderer>().color = newColor;
            }
            else{
                DestroyObject(gameObject);
            }
        }
	}

    private void OnMouseDown()
    {
        isClicked = true;
        if (!isAdded)
        {
            StarsCounter.AddStar();
            isAdded = true;
        }
    }
}
