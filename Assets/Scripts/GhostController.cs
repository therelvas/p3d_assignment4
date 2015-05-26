using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {

		rb.MovePosition(transform.position + (-transform.right) * Time.deltaTime);
		Rotate(100);
	}

	void OnCollisionEnter(Collision collision) {
		Rotate(3);
	}

	protected void Rotate(int max) 
	{	
		//Rotate within a certain range
		switch (Random.Range (0, max)) {
		case 0:
			transform.Rotate (0.0f, 0.0f, 180.0f);
			break;
		case 1:
			transform.Rotate (0.0f, 0.0f, 90.0f);
			break;
		case 2:
			transform.Rotate (0.0f, 0.0f, -90.0f);
			break;
		}
	}
}