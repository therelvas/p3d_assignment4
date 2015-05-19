using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;

	// Position of cursor when mouse dragging starts
	private Vector3 mouseOrigin;

	// Zoom properties
	private float minFov = 20f;
	private float maxFov = 90f;
	private float sensitivity = 5f;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}
	
	void LateUpdate ()
	{
		// Zoom in/out handling
		float fov = GetComponent<Camera>().fieldOfView;

		fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
		fov = Mathf.Clamp(fov, minFov, maxFov);

		GetComponent<Camera>().fieldOfView = fov;

		// Follow player position
		transform.position = player.transform.position + offset;
	}
}