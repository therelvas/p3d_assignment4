using UnityEngine;
using System.Collections;

public class TireController : MonoBehaviour {
	
	void OnTriggerEnter(Collider collider) {

		if(collider.gameObject.name.Contains("tire_cemetery")) {
			gameObject.SetActive(false);
		}
	}
}