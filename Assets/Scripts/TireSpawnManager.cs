using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TireSpawnManager : MonoBehaviour {
	
	public GameObject obj;              // The object prefab to be spawned.
	private List<GameObject> objs;

	public Transform[] spawnPoints;     // An array of the spawn points this enemy can spawn from.
	
	public int spawnLimit = 3;			// Spawn limit.
	public float spawnTime = 3f;        // How long between each spawn.

	private int respawnNum = 0;			// Number of respawns generated
	
	void Start()
	{
		objs = new List<GameObject>();

		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn()
	{		
		// Find a random index between zero and one less than the number of spawn points.
		int spawnPointIndex = Random.Range(0, spawnPoints.Length);

		if (objs.Count < spawnLimit) { // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
			objs.Add((GameObject)Instantiate (obj, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation)); 
		} 
		else { // Reuse instantiated objects

			if(respawnNum == spawnLimit)
				respawnNum = 0; // Reset respawns

			objs[respawnNum].transform.position = spawnPoints[spawnPointIndex].position;
			objs[respawnNum].SetActive(true); // Reactivate object
			respawnNum++;
		} 
	}
}