using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BowlingPin : MonoBehaviour {

	public Text score;
	private GameObject sphere;
	private bool once = true;
	
	void Awake() {
		sphere = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnTriggerEnter (Collider other) {
		if(once)
			if(other.gameObject == sphere) {
				once = false;
				//ADD SCORE
				Globals.score += 10;
				if(Globals.score<1000)
					score.text = (0).ToString()+(Globals.score).ToString();
				else
					score.text = (Globals.score).ToString();
			}
	}

}
