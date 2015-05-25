using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSphereController : MonoBehaviour {

	public float speed;
	private GameObject[] lives;
	private Vector3 initialPosition;

	private Rigidbody rb;
	private Text playerName;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		initialPosition = transform.position;

		playerName = GameObject.Find("PlayerName").GetComponent<Text>();
		playerName.text = Globals.playerName;
		lives = GameObject.FindGameObjectsWithTag("Lives");
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveVertical, 0.0f, -moveHorizontal);
		rb.AddForce(movement * speed);
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name.Equals("GameZone")) {

			Globals.lives--;

			if(Globals.lives < 0) {
				Application.LoadLevel(3);
			}
			else
			{
				rb.velocity = Vector3.zero;
				transform.position = initialPosition;

				foreach(GameObject live in lives) {
					if(live.name.Contains((Globals.lives + 1).ToString())) {
						live.SetActive(false);
					}
				}
			}
		}
	}
}