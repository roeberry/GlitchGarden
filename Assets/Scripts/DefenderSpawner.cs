using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    GameObject defenders;
    float cameraDistance;

	// Use this for initialization
	void Start () {
        cameraDistance = transform.position.z - Camera.main.transform.position.z;
        defenders = GameObject.Find("Defenders");
        if (!defenders){
            defenders = new GameObject();
            defenders.name = "Defenders";
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    Vector3 WorldUnitOfMousePosition(){
        return VectorRound(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDistance)));
    }

    Vector3 VectorRound(Vector3 input){
        return new Vector3(Mathf.Round(input.x), Mathf.Round(input.y), Mathf.Round(input.z));
    }

    private void OnMouseDown()
    {
        if (IsEmpty())
        {
            if (StarsCounter.UseStar(Button.selectedDefender.GetComponent<Defender>().cost))
            {
                GameObject d = Instantiate(Button.selectedDefender, WorldUnitOfMousePosition(), Quaternion.identity);
                d.transform.parent = defenders.transform;
                if (StarsCounter.count < Button.selectedDefender.GetComponent<Defender>().cost)
                {
                    Button.selectedDefender = null;
                }
            }
            else{
                
            }
        }
    }

    bool IsEmpty(){
        Vector2 mousePos = WorldUnitOfMousePosition();
        foreach(Transform t in defenders.transform){
            if (FloatEqual(t.position.x, mousePos.x) &&
                FloatEqual(t.position.y,mousePos.y)){
                return false;
            }
        }
        return true;
    }

    bool FloatEqual(float a, float b){
        return Mathf.Abs(a - b) < 0.001;
    }
}
