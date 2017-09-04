using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public float fireRate;
    public GameObject projectilePrefab;
    public Animator animator;
    public int cost;
    float interval;

    GameObject projectiles;
    GameObject attacker;

	// Use this for initialization
	void Start () {
        //Find Projectiles
        //If found, make projectiles children of it
        //Otherwise, create Projectiles to hold projectiles
        projectiles = GameObject.Find("Projectiles");
        if (!projectiles){
            projectiles = new GameObject();
            projectiles.name = "Projectiles";
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (projectilePrefab && isEnemyInLane())
        {
            interval += Time.deltaTime;
            if (interval > fireRate)
            {
                animator.SetTrigger("Attack");
                interval = 0;
            }
        }
        if (!attacker)
        {
            attacker = GameObject.Find("Attackers");
        }
    }

    void Attack(){
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.transform.parent = projectiles.transform;
    }

    bool isEnemyInLane(){
        if(!attacker){
            return false;
        }
        foreach(Transform t in attacker.transform){
            if(Mathf.Abs(t.position.y-transform.position.y)<0.001){
                if (t.position.x < 9f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
