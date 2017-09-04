using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {

    public GameObject[] prefabs;

    List<float>[] spawnArraries = new List<float>[3];

    public Vector4[] spawnAreas;

    GameObject attackers;

	// Use this for initialization
	void Start () {
        attackers = GameObject.Find("Attackers");
        if(!attackers){
            attackers = new GameObject();
            attackers.name = "Attackers";
        }
        if (PlayerPrefsManager.GetDifficulty() == 2) //normal
        {
            spawnArraries[0] = new List<float>() { 22, 35, 49, 52 };
            spawnArraries[1] = new List<float>();
            spawnArraries[2] = new List<float>();
        }
        else if (PlayerPrefsManager.GetDifficulty() == 1) //easy
		{
			spawnArraries[0] = new List<float>() { 25, 40, 52};
			spawnArraries[1] = new List<float>();
			spawnArraries[2] = new List<float>();
        }
		else if (PlayerPrefsManager.GetDifficulty() == 3) //hard
		{
            spawnArraries[0] = new List<float>() { 22, 35, 49, 50, 50, 52, 52, 52 };
			spawnArraries[1] = new List<float>();
			spawnArraries[2] = new List<float>();
		}
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i != 3; i++)
        {
            if (spawnArraries[i].Count > 0)
            {
                if (Time.timeSinceLevelLoad > spawnArraries[i][0])
                {
                    Vector3 spawnPos = new Vector3(Mathf.Round(Random.Range(spawnAreas[i].x, spawnAreas[i].z)),
                                                   Mathf.Round(Random.Range(spawnAreas[i].y, spawnAreas[i].w)),
                                                   0);
                    GameObject attacker = Instantiate(prefabs[i], spawnPos, Quaternion.identity);
                    attacker.transform.parent = attackers.transform;
                    spawnArraries[i].RemoveAt(0);
                }
            }
        }

    }
}
