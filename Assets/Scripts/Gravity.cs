using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	private GameObject sphere;

	void Start() {
		sphere = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject.Equals(sphere))
			sphere.GetComponent<Rigidbody>().AddForce(-Physics.gravity * sphere.GetComponent<Rigidbody>().mass * 13);
	}
}