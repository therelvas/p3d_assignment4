using UnityEngine;
using System.Collections;

public class TireController : MonoBehaviour {
	
	public int thrust;
	private Rigidbody rb;
	public Vector3 impulseDirection;
	
	public void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	public void FixedUpdate() {
		//rb.velocity = Vector3.zero;
		rb.AddForce(impulseDirection * thrust, ForceMode.Impulse);
	}
	
	private void OnTriggerEnter(Collider collider) {
		
		if(collider.gameObject.name.Contains("tire_cemetery")) {
			gameObject.SetActive(false);
		}
	}
}