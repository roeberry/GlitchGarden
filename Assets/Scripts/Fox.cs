using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

    float interval;

    Attacker attacker;

    public float floatRunInterval;

	// Use this for initialization
	void Start () {
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
        interval += Time.deltaTime;
        if (interval > floatRunInterval){
            attacker.animator.SetBool("isRunning", true);
        }
        if(attacker.animator.GetBool("isAttacking")){
            interval = 0;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Contains("Fox Ranger")){
            attacker.animator.SetTrigger("Jump");
            attacker.animator.SetBool("isAttacking", false);
            attacker.animator.SetBool("isRunning", false);
            interval = 0;
        }
    }
}
