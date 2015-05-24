using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	private GameObject sphere;

	void Start() {
		sphere = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {

	}

	void OnTriggerEnter(Collider other) {

	}

}
