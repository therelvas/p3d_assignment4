using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Diamond : MonoBehaviour {

	public AudioClip diamondGrab;
	public Text score;
	private GameObject sphere;

	void Awake() {
		sphere = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter (Collider other) {
		if(other.gameObject == sphere) {
			AudioSource.PlayClipAtPoint(diamondGrab, transform.position);
			//ADD SCORE
			Globals.score += 100;
			if(Globals.score<1000)
				score.text = (0).ToString()+(Globals.score).ToString();
			else
				score.text = (Globals.score).ToString();
			Destroy(gameObject);
		}
	}
}
