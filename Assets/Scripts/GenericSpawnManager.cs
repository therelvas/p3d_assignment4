using UnityEngine;
using System.Collections;

public class GenericSpawnManager : MonoBehaviour {
	
	public GameObject obj;           // The object prefab to be spawned.
	public Transform[] spawnPoints;  // An array of the spawn points this enemy can spawn from.
	
	void Start()
	{
		for (int i = 0; i < spawnPoints.Length; i++) {
			Instantiate(obj, spawnPoints[i].position, spawnPoints[i].rotation);
		}
	}
}
