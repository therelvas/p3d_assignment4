using UnityEngine;
using System.Collections;

public class TurnLightsOn : MonoBehaviour {

	public GameObject[] l;
	public GameObject sphere;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.Equals(sphere)) {
			foreach (GameObject light in l)
				light.transform.GetComponent<Light>().enabled = true;
		}
	}
}
