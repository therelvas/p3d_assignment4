using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PickUpObject : MonoBehaviour {
	
	private Text score;
	public int scoreIncrement;
	public AudioClip grabSound;

	public void Start() 
	{
		score = GameObject.Find("Score").GetComponent<Text>();
	}

	void OnTriggerEnter (Collider collider) 
	{
		if(collider.gameObject.gameObject.name.Equals("player_sphere")) 
		{
			AudioSource.PlayClipAtPoint(grabSound, transform.position);

			// Add score
			Globals.score += scoreIncrement;
			if(Globals.score < Globals.maxScore) {
				score.text = (0).ToString() + (Globals.score).ToString();
			}
			else {
				score.text = (Globals.score).ToString();
			}
			Destroy(gameObject);
		}
	}
}
