using UnityEngine;
using System.Collections;

public class RotativeFloorController : MonoBehaviour {
	
	public float rotationSpeed = 80.0f;

	private Rigidbody rb = null;
	private Vector3 eulerAngleVelocity;

	// Initilization
	void Start() {
		rb = GetComponent<Rigidbody>();
		eulerAngleVelocity = new Vector3(0.0f, rotationSpeed, 0.0f);
	}

	// Update is called once per frame
	void FixedUpdate() {
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
		rb.MoveRotation(rb.rotation * deltaRotation);
	}
}