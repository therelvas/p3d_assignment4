using UnityEngine;
using System.Collections;

public class PacMan : MonoBehaviour {
	public AudioClip pacSound;
	public GameObject sphere;

	void OnTriggerEnter (Collider collider) 
	{
		if(collider.gameObject.tag.Equals("Player")) 
		{
			AudioSource.PlayClipAtPoint(pacSound, sphere.transform.position);
			sphere.GetComponent<Renderer>().material.color = Color.yellow;
		}
	}
}
