using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
	public Button playBtn;

	// Use this for initialization
	void Start () {
		playBtn = playBtn.GetComponent<Button> ();
	}
	
	public void StartPressed (){
		Application.LoadLevel (1);
	}
}
