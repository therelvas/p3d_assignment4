using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSphereController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public Text playerName;
	public GameObject gamezone;
	private Vector3 initialPosition;
	private GameObject[] lives;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		playerName.text = Globals.playerName;
		initialPosition = transform.position;
		lives = GameObject.FindGameObjectsWithTag("Lives");
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveVertical, 0.0f, -moveHorizontal);
		
		rb.AddForce(movement * speed);
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.Equals(gamezone)){
			Globals.lives--;
			if(Globals.lives < 0)
				Application.LoadLevel(3);
			else{
				transform.position = initialPosition;
				rb.velocity = Vector3.zero;
				foreach(GameObject live in lives)
					if(live.name.Contains((Globals.lives+1).ToString()))
						live.SetActive(false);
			}
		}
	}
}