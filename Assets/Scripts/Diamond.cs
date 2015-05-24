using UnityEngine;
using System.Collections;

public class Diamond : MonoBehaviour {

	public AudioClip diamondGrab;

	private GameObject sphere;

	void Awake() {
		sphere = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject == sphere) {
			AudioSource.PlayClipAtPoint(diamondGrab, transform.position);
			//ADD SCORE
			Destroy(gameObject);
		}
	}
}
