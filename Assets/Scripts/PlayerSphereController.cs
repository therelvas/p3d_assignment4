using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerSphereController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	public Text playerName;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		playerName.text = Globals.playerName;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3 (moveVertical, 0.0f, -moveHorizontal);
		
		rb.AddForce(movement * speed);
	}
}