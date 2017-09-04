using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float health = 10f;

    const float redDuration = 0.2f;
    float interval = redDuration + 1;
    bool isTakenDamage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        interval += Time.deltaTime;
        if (interval > redDuration&&isTakenDamage)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
            isTakenDamage = false;
        }
	}

    public void takeDamage(float damage){
        health -= damage;
        GetComponentInChildren<SpriteRenderer>().color=Color.red;
        interval = 0;
        isTakenDamage = true;
        if(health<=0){
            Invoke("Destroy", 0.5f);
        }
    }

    void Destroy(){
        DestroyObject(gameObject);
    }
}
