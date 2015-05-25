using UnityEngine;
using System.Collections;

public class NavRampUp : MonoBehaviour {

	private int dir = 1;
	private float speed = 1f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * dir * speed);
		if(transform.position.y >11f)
			dir = -1;
		if(transform.position.y <8.3f)
			dir=1;
	}	
}
