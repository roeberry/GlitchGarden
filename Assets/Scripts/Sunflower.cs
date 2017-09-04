using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour {

    public GameObject starPrefab;


    public float spawnRate;
    float interval;
    GameObject projectiles;

	// Use this for initialization
	void Start () {
		projectiles = GameObject.Find("Projectiles");
		if (!projectiles)
		{
			projectiles = new GameObject();
			projectiles.name = "Projectiles";
		}
	}
	
	// Update is called once per frame
	void Update () {
        interval += Time.deltaTime;
        if(interval>spawnRate){
            GameObject star = Instantiate(starPrefab, transform.position, Quaternion.identity);
            star.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 2f);
            star.transform.parent = projectiles.transform;
            star.GetComponent<Star>().sunflower = gameObject;
            interval = 0;
        }
	}
}
