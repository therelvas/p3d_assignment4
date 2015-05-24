using UnityEngine;
using System.Collections;

public class NavRamp : MonoBehaviour {

	private int dir = 1;
	private float speed = 0.5f;

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * dir * speed);
		if(transform.position.x >11.5f)
			dir = -1;
		if(transform.position.x <10.5f)
			dir=1;

	}		    

}
